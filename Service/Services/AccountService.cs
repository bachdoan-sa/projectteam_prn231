using Invedia.DI.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebApp.Repository.Entities;
using WebApp.Repository.Repositories.IRepositories;
using WebApp.Service.IServices;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using WebApp.Repository;
using Microsoft.Extensions.DependencyInjection;
using WebApp.Core.Models.AccountModels;
using WebApp.Core.Constants;
using AutoMapper;

namespace WebApp.Service.Services
{
    [ScopedDependency(ServiceType = typeof(IAccountService))]
    public class AccountService : Base.Service, IAccountService
    {
        private readonly IConfiguration _configuration;
        private readonly IAccountRepository _accountRepository;
        private readonly IRoleRepository _roleRepository;

        public AccountService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _configuration = serviceProvider.GetRequiredService<IConfiguration>();
            _accountRepository = serviceProvider.GetRequiredService<IAccountRepository>();
            _roleRepository = serviceProvider.GetRequiredService<IRoleRepository>();
        }

        //Code below to test Method Hash and Salt password by using HMACSHA512
        /* public Task<AccountRegisterModel> test(AccountRegisterModel accountRegisterModel)
         {
             AccountRegisterModel account = new AccountRegisterModel();
             account.PasswordHash = CreatePasswordHash(accountRegisterModel.Password, out byte[] passwordSalt);
             account.PasswordSalt = Convert.ToBase64String(passwordSalt);
             account.PasswordHash = accountRegisterModel.PasswordHash;
             account.PasswordSalt = accountRegisterModel.PasswordSalt;
             if (VerifyPasswordHash(accountRegisterModel.Password, Convert.FromBase64String(account.PasswordHash), Convert.FromBase64String(account.PasswordSalt)))
             {
                 account.UserName = "ok";
             }
             return Task.FromResult(account);
         }*/
        public Task<string> RegisterAccount(AccountRegisterModel accountRegisterModel)
        {
            //This case we checked input data validation!
            //Step-1 check the Email or UserName, makesure it not already exsit.

            //Step-2 Convert data from Model to Entity.
            //2.1 password encryption by hash and salt method
            var passwordHash = CreatePasswordHash(accountRegisterModel.Password, out byte[] passwordSalt);
            //2.2 create new model and add sub infomation
            var customerRole = _roleRepository.Get(_ => _.RoleName == UserRole.CUSTOMER).FirstOrDefault();

            var account = new Account
            {
                UserName = accountRegisterModel.UserName,
                PasswordHash = Convert.ToBase64String(passwordHash),
                PasswordSalt = Convert.ToBase64String(passwordSalt),
                Email = accountRegisterModel.Email,
                Phone = accountRegisterModel.Phone,
                Address = accountRegisterModel.Address,
                Birthdate = accountRegisterModel.Birthday,
                RoleId = customerRole.Id,

            };

            //Step-3 Add to Database, save changes and return JWT.
            _accountRepository.Add(account);
            UnitOfWork.SaveChange();

            return Task.FromResult(CreateBearerToken(account));
        }
        public Task<string> LoginAccount(AccountLoginModel loginModel)
        {
            string AdminId = _configuration.GetValue<string>("AdminAccount:Id");
            string AdminUserName = _configuration.GetValue<string>("AdminAccount:UserName");
            string AdminPassword = _configuration.GetValue<string>("AdminAccount:Password");
            if (loginModel.UserName == AdminUserName && loginModel.Password == AdminPassword) 
            {
                Account AdminAcc = new Account
                {
                    Id = AdminId
                };
                return Task.FromResult(CreateBearerToken(AdminAcc));
            }
            else
            {
                var user = _accountRepository.Get(_ => _.UserName == loginModel.UserName).FirstOrDefault();
                if (user != null)
                {
                    var check = VerifyPasswordHash(loginModel.Password,
                        Convert.FromBase64String(user.PasswordHash),
                        Convert.FromBase64String(user.PasswordSalt));
                    if (check)
                    {
                        return Task.FromResult(CreateBearerToken(user));
                    }
                }
            }
            return Task.FromResult(ErrorCode.UserFailAuth);
        }
        public Task<List<Account>> GetAccounts()
        {
            /* ví dụ: _repository.Get(_ => _.UserName.Contains("a"),false,_=>_.Orchids)
                _ => _.UserName.Contains("a") là query options
                false là có lấy những đối tượng bị xóa luôn ko
                _=>_.Orchids là bao gồm các bảng nào 'include options'
             */
            var list = _accountRepository.Get().ToListAsync();
            return list;
        }

        #region Private Methods
        private byte[] CreatePasswordHash(string password, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                return hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        /* private Guid GetSidLogged()
         {
             var sid = _http.HttpContext?.User.FindFirst(ClaimTypes.Sid)?.Value;
             if (sid == null)
             {
                 throw new Exception(ErrorCode.USER_NOT_FOUND);
             }
             return Guid.Parse(sid);
         }*/

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }

        private string CreateBearerToken(Account logUser)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Sid, logUser.Id.ToString())
            };
#pragma warning disable CS8604 // Possible null reference argument.
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
#pragma warning restore CS8604 // Possible null reference argument.
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                                             claims: claims,
                                             expires: DateTime.Now.AddDays(7),
                                             signingCredentials: creds
                                            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return "bearer " + tokenString;
        }

        // Check the token is valid and not expired
        private bool CheckTokenIsExpires(string token)
        {
            // remove bearer from token
            token = token.Substring(7);
            var tokenHandler = new JwtSecurityTokenHandler();
#pragma warning disable CS8604 // Possible null reference argument.
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Token").Value);
#pragma warning restore CS8604 // Possible null reference argument.
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            }, out SecurityToken validatedToken);
            return validatedToken.ValidTo < DateTime.UtcNow;
        }

        // Create otp code
        private string GenerateOtpCode()
        {
            var otpCode = new Random().Next(100000, 999999).ToString();
            return otpCode;
        }


        #endregion
    }
}

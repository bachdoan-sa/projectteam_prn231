using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebApp.Repository.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using WebApp.Core.Models.AccountModels;

namespace WebApp.Service.IServices
{
    public interface IAccountService
    {
        //Add method here :v
        public Task<List<AccountModel>> GetAccounts();
        public Task<Account> GetAccountById(string id);
        public Task<string> RegisterAccount(AccountRegisterModel model);
        public Task<string> LoginAccount(AccountLoginModel model);
        public Task<string> CreateAccount(AccountModel account);
        public Task<string> GetWhoYouAre();
    }
}

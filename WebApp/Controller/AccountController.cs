using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Core.Constants;
using WebApp.Core.Models.AccountModels;
using WebApp.Service.IServices;
using WebApp.Service.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controller
{

    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [Route(WebApiEndpoint.Account.SignUpAccount)]
        [HttpPost]
        public async Task<IActionResult> Register(AccountRegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(ModelState.ToList());
            }
            var test = await _accountService.RegisterAccount(model);
            if (test == null)
            {
                return BadRequest();
            }
            return Ok(test);
        }
        [Route(WebApiEndpoint.Account.SignInAccount)]
        [HttpPost]
        public async Task<IActionResult> Login(AccountLoginModel model)
        {
            try
            {
                var test = await _accountService.LoginAccount(model);
                if (test == null)
                {
                    return BadRequest();
                }
                return Ok(test);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("~/api/Account/getwholognow")]
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> GetWho()
        {
            try
            {
                var test = await _accountService.GetWhoYouAre();
                if (test == null)
                {
                    return BadRequest();
                }
                return Ok(test);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route(WebApiEndpoint.Account.GetUserRole)]
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUserRole()
        {
            var role = await _accountService.GetLogUserRole();
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }
        // GET: api/<AccountController>
        [Authorize(Roles = UserRole.ADMIN)]
        [Route(WebApiEndpoint.Account.GetAllAccount)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _accountService.GetAccounts();

            return Ok(list);
        }

        // GET api/<AccountController>/5
        /*[Authorize]*/
        [Route(WebApiEndpoint.Account.GetAccount)]
        [HttpGet]
        public async Task<IActionResult> GetSingle(string id)
        {
            var acc = await _accountService.GetAccountById(id);
            return Ok(acc);
        }
        // POST api/<AccountController>
        [Authorize(Roles = UserRole.ADMIN)]
        [Route(WebApiEndpoint.Account.AddAccount)]
        [HttpPost]
        public async Task<IActionResult> AddAccount(AccountModel model)
        {
            var list = await _accountService.CreateAccount(model);
            return Ok(list);
        }

        [Authorize(Roles = UserRole.ADMIN)]
        [Route(WebApiEndpoint.Account.UpdateAccount)]
        [HttpPut]
        public async Task<IActionResult> UpdateAccount([FromBody] AccountModel updatedAccount)
        {
            var result = await _accountService.UpdateAccount(updatedAccount);
            return Ok(result);
        }

        
        [Authorize]
        [HttpGet("/api/Account/Customer")]
        public async Task<IActionResult> GetSingleCustomer()
        {
            var acc = await _accountService.GetAccountByLogId();
            return Ok(acc);
        }
        /*
        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public void Put(string value)
        {
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}

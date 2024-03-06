using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Core.Constants;
using WebApp.Core.Models.AccountModels;
using WebApp.Service.IServices;

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
        [Authorize]
        [Route(WebApiEndpoint.Account.GetAccount)]
        [HttpGet]
        public async Task<IActionResult> GetSingle(string id)
        {
            var acc = await _accountService.GetAccountById(id);
            return Ok(acc);
        }
        // POST api/<AccountController>
        [Authorize]
        [Route(WebApiEndpoint.Account.AddAccount)]
        [HttpPost]
        public async Task<IActionResult> AddAccount(AccountModel model)
        {
            var list = await _accountService.CreateAccount(model);
            return Ok(list);
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

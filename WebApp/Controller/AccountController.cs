using Microsoft.AspNetCore.Mvc;
using WebApp.Core.Models.AccountModels;
using WebApp.Service.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(AccountRegisterModel model)
        {
            var test = await _accountService.RegisterAccount(model);
            if(test == null)
            {
                return BadRequest();
            }
            return Ok(test);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(AccountLoginModel model)
        {
            var test = await _accountService.LoginAccount(model);
            if (test == null)
            {
                return BadRequest();
            }
            return Ok(test);
        }
        // GET: api/<AccountController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await _accountService.GetAccounts();

            return Ok(list);
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AccountController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

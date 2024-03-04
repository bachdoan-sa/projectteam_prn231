using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Core.Constants;
using WebApp.Core.Models.AccountModels;
using WebApp.Core.Models.RoleModels;
using WebApp.Service.IServices;
using WebApp.Service.Services;

namespace WebApp.Controller
{
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [Route(WebApiEndpoint.Role.GetAllRole)]
        [HttpGet]
        public async Task<IActionResult> GetAllRole()
        {
            var test = await _roleService.GetRoles();
            if (test == null)
            {
                return BadRequest();
            }
            return Ok(test);
        }
        [Route(WebApiEndpoint.Role.AddRole)]
        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleModel model)
        {
            var test = await _roleService.AddRole(model);
            if (test == null)
            {
                return BadRequest();
            }
            return Ok(test);
        }
    }
}

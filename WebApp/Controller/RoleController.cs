using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Core.Constants;
using WebApp.Core.Models.AccountModels;
using WebApp.Core.Models.RoleModels;
using WebApp.Service.IServices;
using WebApp.Service.Services;

namespace WebApp.Controller
{
    [Authorize(Roles = UserRole.ADMIN)]
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
        [Authorize(Roles = UserRole.ADMIN)]
        [Route(WebApiEndpoint.Role.AddRole)]
        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleModel model)
        {
            throw new NotImplementedException();
            var test = await _roleService.AddRole(model);
            if (test == null)
            {
                return BadRequest();
            }
            return Ok(test);
        }

        [Route(WebApiEndpoint.Role.GetRole)]
        [HttpGet]
        public async Task<IActionResult> Get(string id)
        {
            var role = await _roleService.GetRoleById(id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }
        [Authorize(Roles = UserRole.ADMIN)]
        [Route(WebApiEndpoint.Role.UpdateRole)]
        [HttpPut]
        public async Task<IActionResult> Update( RoleModel role)
        {
            try
            {
                throw new NotImplementedException();

                var updatedRole = await _roleService.UpdateRole(role);
                if (updatedRole == null)
                {
                    return NotFound();
                }
                return Ok(updatedRole);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while updating the role.");
            }
        }
    }
}

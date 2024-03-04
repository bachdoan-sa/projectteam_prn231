using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Models.RoleModels;
using WebApp.Repository.Entities;

namespace WebApp.Service.IServices
{
    public interface IRoleService
    {
        public Task<List<Role>> GetRoles();
        public Task<string> AddRole(RoleModel model);
    }
}

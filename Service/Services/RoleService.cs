using Invedia.DI.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Models.RoleModels;
using WebApp.Repository.Entities;
using WebApp.Repository.Repositories;
using WebApp.Repository.Repositories.IRepositories;
using WebApp.Service.IServices;

namespace WebApp.Service.Services
{
    [ScopedDependency(ServiceType = typeof(IRoleService))]
    public class RoleService : Base.Service, IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _roleRepository = serviceProvider.GetRequiredService<IRoleRepository>();

        }
        public Task<string> AddRole(RoleModel model)
        {
            if(string.IsNullOrEmpty(model.RoleName)) 
            {
                throw new Exception("Data gui ve rong");
            }
            var role = new Role();
            role.RoleName = model.RoleName.ToUpper();

            _roleRepository.Add(role);
            UnitOfWork.SaveChange();
            return Task.FromResult(role.Id);
        }

        public Task<List<Role>> GetRoles()
        {
            return Task.FromResult(_roleRepository.Get().ToList());
        }

        public  Task<Role> GetRoleById(string id)
        {
            return _roleRepository.Get(role => role.Id == id).FirstOrDefaultAsync();
        }

        public  Task<string> UpdateRole(RoleModel role)
        {
            // Check if the role exists
            var existingRole =  _roleRepository.Get(_ => _.Id.Equals(role.Id)).FirstOrDefault();
            if (existingRole != null)
            {
                // Update the properties of the existing role
                existingRole.RoleName = role.RoleName;
                existingRole.LastUpdated = DateTimeOffset.UtcNow;

                _roleRepository.Update(existingRole);
                UnitOfWork.SaveChange();
            }

            return Task.FromResult(existingRole.Id);
        }
    }
}

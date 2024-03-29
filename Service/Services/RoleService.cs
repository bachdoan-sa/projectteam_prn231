﻿using Invedia.DI.Attributes;
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
    }
}

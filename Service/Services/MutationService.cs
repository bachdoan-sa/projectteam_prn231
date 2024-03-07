using AngleSharp.Dom;
using Invedia.DI.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Repository.Entities;
using WebApp.Repository.Repositories.IRepositories;
using WebApp.Service.IServices;

namespace WebApp.Service.Services
{
    [ScopedDependency(ServiceType = typeof(IMutationService))]
    public class MutationService : Base.Service, IMutationService
    {
        private readonly IMutationRepository _repository;


        public MutationService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _repository = serviceProvider.GetRequiredService<IMutationRepository>();
            
        }
    
    public Task CreateMutaion(Mutation mutation)
        {
            throw new NotImplementedException();
        }

        public Task<List<Mutation>> GetAllMutations()
        {
            var list = _repository.Get().ToListAsync();
            return list;
        }

        public Task<Mutation> GetMutationById(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMutaion(Mutation mutation)
        {
            throw new NotImplementedException();
        }
    }
}

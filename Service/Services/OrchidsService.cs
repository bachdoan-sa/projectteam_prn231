using System;
using Microsoft.Extensions.Configuration;
using WebApp.Repository.Entities;
using WebApp.Service.IServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Repository.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using Invedia.DI.Attributes;

namespace WebApp.Service.Services
{
    [ScopedDependency(ServiceType = typeof(IOrchidsService))]
    public class OrchidsService : IOrchidsService
    {
        private readonly IOrchidsRepository _orchidsRepository;

        public OrchidsService(IOrchidsRepository orchidsRepository)
        {
            _orchidsRepository = orchidsRepository;
        }

        public Task<List<Orchid>> GetAllOrchids()
        {
            var list = _orchidsRepository.Get().ToListAsync();
            return list;
        }

        public Task<Orchid?> GetOrchidById(string id)
        {
            var orchid = _orchidsRepository.Get(orchid => orchid.Id == id).FirstOrDefaultAsync();
            return orchid;
        }

        public Task AddOrchid(Orchid orchid)
        {
            var addorchid = _orchidsRepository.Add(orchid);
            return Task.FromResult(addorchid);
        }


        public Task UpdateOrchid(Orchid orchid)
        {
            var existingOrchids = _orchidsRepository.GetSingle(x => x.Id == orchid.Id);
            if (existingOrchids != null)
            {


                
                existingOrchids.Name = orchid.Name;
                existingOrchids.Description = orchid.Description;
                existingOrchids.Price = orchid.Price;
                existingOrchids.OrchidCategory = orchid.OrchidCategory;
                existingOrchids.OrchidStatus = orchid.OrchidStatus;



                _orchidsRepository.Update(existingOrchids);

            }
            return Task.FromResult(existingOrchids.Id);
        }

    }
}
using Invedia.DI.Attributes;
using Microsoft.EntityFrameworkCore;
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
    [ScopedDependency(ServiceType = typeof(IDealHangerService))]
    public class DealHangerService : IDealHangerService
    {
        private readonly IDealHangerRepository _repository;

        public DealHangerService(IDealHangerRepository repository)
        {
            _repository = repository;

        }

        public Task<DealHanger> CreateDealHanger(DealHanger dealHanger)
        {
            var createDealHanger = _repository.Add(dealHanger);
            return Task.FromResult(createDealHanger);
        }

        public Task<List<DealHanger>> GetAllDealhangers()
        {
            var list = _repository.Get().ToListAsync();
            return list;
        }

        public Task<DealHanger> GetDealHangerById(string id)
        {
            var dealHanger = _repository.Get(dealHanger => dealHanger.Id == id).FirstOrDefaultAsync();
            return dealHanger;
        }

        public Task<string> UpdateDealHanger(DealHanger dealHanger)
        {
            var existingDealHanger = _repository.GetSingle(x => x.Id == dealHanger.Id);
            if (existingDealHanger != null)
            {
                existingDealHanger.DealStatus =  dealHanger.DealStatus;
                existingDealHanger.Currency = dealHanger.Currency;

                _repository.Update(existingDealHanger);

            }
            return Task.FromResult(existingDealHanger.Id);
        }
    }
}

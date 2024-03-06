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
using WebApp.Core.Models.OrchidModels;
using WebApp.Repository.Base;
using WebApp.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace WebApp.Service.Services
{
    [ScopedDependency(ServiceType = typeof(IOrchidsService))]
    public class OrchidsService : Base.Service, IOrchidsService
    {
        private readonly IOrchidsRepository _orchidsRepository;

        public OrchidsService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _orchidsRepository = serviceProvider.GetRequiredService<IOrchidsRepository>();
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

        public Task<string> AddOrchid(OrchidModel model)
        {
            var orchid = new Orchid();
            orchid.Name = model.Name;
            orchid.Description = model.Description;
            orchid.Price = model.Price;
            orchid.OrchidStatus = model.OrchidStatus;
            orchid.OrchidCategoryId = model.OrchidCategoryId;
            orchid.ProductOwnerId = model.ProductOwnerId;

            _orchidsRepository.Add(orchid);
            UnitOfWork.SaveChange();
            return Task.FromResult(orchid.Id);
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

        public async Task<List<OrchidModel>> GetOrchidByProductOwnerId(string id)
        {
            var orchids = await _orchidsRepository.Get(orchid => orchid.ProductOwnerId == id).ToListAsync();
            var orchidModels = orchids.Select(orchid => new OrchidModel
            {
                Name = orchid.Name,
                Description = orchid.Description,
                Price = orchid.Price,
                OrchidStatus = orchid.OrchidStatus,
                OrchidCategoryId = orchid.OrchidCategoryId,
                ProductOwnerId = id
            }).ToList();

            return orchidModels;
        }
    }
}
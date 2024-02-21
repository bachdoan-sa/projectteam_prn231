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
    [ScopedDependency(ServiceType = typeof(IOrchidMutationService))]
    public class OrchidsMutationService : IOrchidMutationService
    {
        private readonly IOrchidMutationsRepository _orchidMutationsRepository;

        public OrchidsMutationService(IOrchidMutationsRepository Repository)
        {
            _orchidMutationsRepository = Repository;
        }

        public Task<List<OrchidMutation>> GetAllOrchidMutation()
        {
            var list = _orchidMutationsRepository.Get().ToListAsync();
            return list;
        }

        public Task<OrchidMutation?> GetOrchidMutationById(string id)
        {
            var orchidMutation = _orchidMutationsRepository.Get(orchidMutation => orchidMutation.Id == id).FirstOrDefaultAsync();
            return orchidMutation;
        }

        public Task AddOrchidMutaion(OrchidMutation orchidMutation)
        {
            var addorchid = _orchidMutationsRepository.Add(orchidMutation);
            return Task.FromResult(addorchid);
        }


        public Task UpdateOrchidMutaion(OrchidMutation orchidMutation)
        {
            var existingOrchids = _orchidMutationsRepository.GetSingle(x => x.Id == orchidMutation.Id);
            if (existingOrchids != null)
            {
                existingOrchids.Color = orchidMutation.Color;
                existingOrchids.Size = orchidMutation.Size;
                existingOrchids.Shape = orchidMutation.Shape;

                _orchidMutationsRepository.Update(existingOrchids);

            }
            return Task.FromResult(existingOrchids.Id);
        }




    }
}
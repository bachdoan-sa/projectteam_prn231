using Invedia.DI.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Models.MutationModels;
using WebApp.Repository.Entities;
using WebApp.Repository.Repositories.IRepositories;
using WebApp.Service.IServices;

namespace WebApp.Service.Services
{
    [ScopedDependency(ServiceType = typeof(IMutationService))]
    public class MutationService : Base.Service, IMutationService
    {
        private readonly IMutationRepository _mutationRepository;
        public MutationService(IServiceProvider serviceProvider) : base(serviceProvider) 
        {
            _mutationRepository = serviceProvider.GetRequiredService<IMutationRepository>();
        }


        public Task<string> CreateMutaion(MutationModel model)
        {
            var entity = _mapper.Map<Mutation>(model);
            _mutationRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task<string> DeleteMutaion(string id)
        {
                var entity = _mutationRepository.Get(_ => _.Id.Equals(id)).FirstOrDefault();
                if (entity == null)
                {
                    return Task.FromResult("Not Found Mutation Need Delete");
                }
                entity.DeleteTime = DateTime.UtcNow;
                _mutationRepository.Update(entity);
                UnitOfWork.SaveChange();
                return Task.FromResult("Delete Mutation Successfully");   
        }

        public Task<List<MutationModel>> GetAllMutations()
        {
            var list = _mutationRepository.Get().ToListAsync().Result;
            var result = _mapper.Map<List<MutationModel>>(list);
            return Task.FromResult(result);
                
        }

        public Task<MutationModel> GetMutationById(string id)
        {
            var entity = _mutationRepository.Get(_=>_.Id.Equals(id)).FirstOrDefault();
            var result = _mapper.Map<MutationModel>(entity);
            return Task.FromResult(result);
        }

        public Task<string> UpdateMutaion(MutationModel mutation)
        {
            var entity = _mutationRepository.Get(_=>_.Id.Equals(mutation.Id)).FirstOrDefault();
            if (entity == null) 
            {
                return Task.FromResult("Not Found Auction Need Update");
            }
            entity.MutationPosition = mutation.MutationPosition;
            _mutationRepository.Update(entity);
            UnitOfWork.SaveChange() ;
            return Task.FromResult(entity.Id);
        }
    }
}

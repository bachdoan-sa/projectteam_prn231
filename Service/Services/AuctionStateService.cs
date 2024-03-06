using Invedia.DI.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Models.AuctionStateModels;
using WebApp.Repository.Entities;
using WebApp.Repository.Repositories;
using WebApp.Repository.Repositories.IRepositories;
using WebApp.Service.IServices;

namespace WebApp.Service.Services
{
    [ScopedDependency(ServiceType = typeof(IAuctionStateService))]
    public class AuctionStateService : Base.Service,IAuctionStateService
    {
        private readonly IAuctionStateRepository _auctionStateRepository;
        public AuctionStateService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _auctionStateRepository = serviceProvider.GetRequiredService<IAuctionStateRepository>();
        }
        public Task<List<AuctionState>> GetAllAuctionStates()
        {
            var list  = _auctionStateRepository.Get().ToListAsync();
            return list;
        }

        public Task<AuctionStateModel> GetAuctionStateById(string id)
        {
            var entity = _auctionStateRepository.Get(_ => _.Id.Equals(id)).FirstOrDefault();
            var result = _mapper.Map<AuctionStateModel>(entity);
            return Task.FromResult(result);
        }

        public Task<string> CreateAuctionState(AuctionStateModel model)
        {
            var entity = new AuctionState
            {
                Position = model.Position,
                StartingPrice = model.StartingPrice,
                ExpectedPrice = model.ExpectedPrice,
                MinRaise = model.MinRaise,
                MaxRaise = model.MaxRaise,
                AuctionStateStatus = model.AuctionStateStatus,
                FinalPrice = model.FinalPrice,
            };
            _auctionStateRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }
        public Task<string> UpdateAuctionState(AuctionStateModel auctionState)
        {
            var entity = _auctionStateRepository.Get(_ => _.Id.Equals(auctionState.Id)).FirstOrDefault();

            if (entity == null)
            {
                return Task.FromResult("Not Found Auction Need Update");
            }
           
                entity.Position = auctionState.Position;
                entity.StartingPrice = auctionState.StartingPrice;
                entity.ExpectedPrice = auctionState.ExpectedPrice;
                entity.MinRaise = auctionState.MinRaise;
                entity.MaxRaise = auctionState.MaxRaise;
                entity.AuctionStateStatus = auctionState.AuctionStateStatus;
                entity.FinalPrice = auctionState.FinalPrice;

                _auctionStateRepository.Update(entity);
                UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }
        public Task<string> DeleteAuctionState(string id)
        {
            var entity = _auctionStateRepository.Get(_ => _.Id.Equals(id)).FirstOrDefault();
            if(entity != null)
            _auctionStateRepository.Delete(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult("Delete Successfully");
        }
        /* 
          public Task UpdateAuctionState(AuctionState auctionState)
          {
              throw new NotImplementedException();
          }
        */

        public Task<List<OrchidAuctionModel>> GetOrchidAuctions()
        {
            var listEntities = _auctionStateRepository.Get(null,false, _ => _.Orchid, _ => _.AuctionEvent,_ => _.DealHangers).ToList();
            var result = _mapper.Map<List<OrchidAuctionModel>>(listEntities);
            return Task.FromResult(result);
        }

        public Task<OrchidAuctionModel> GetOrchidAuction(string id)
        {
            var entity = _auctionStateRepository.Get(_ => _.Id == id, false, _ => _.Orchid, _ => _.AuctionEvent, _ => _.DealHangers).FirstOrDefault();
            var result = _mapper.Map<OrchidAuctionModel>(entity);
            return Task.FromResult(result);
        }
        
    }
}

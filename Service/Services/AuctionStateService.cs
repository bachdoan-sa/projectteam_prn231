using Invedia.DI.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Models.AuctionEventModels;
using WebApp.Core.Models.AuctionStateModels;
using WebApp.Repository.Base;
using WebApp.Repository.Base.Interface;
using WebApp.Repository.Entities;
using WebApp.Repository.Repositories;
using WebApp.Repository.Repositories.IRepositories;
using WebApp.Service.IServices;

namespace WebApp.Service.Services
{
    [ScopedDependency(ServiceType = typeof(IAuctionStateService))]
    public class AuctionStateService : Base.Service, IAuctionStateService
    {
        private readonly IAuctionStateRepository _auctionStateRepository;
        private readonly IAuctionEventRepository _auctionEventRepository;
        public AuctionStateService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _auctionStateRepository = serviceProvider.GetRequiredService<IAuctionStateRepository>();
            _auctionEventRepository = serviceProvider.GetRequiredService<IAuctionEventRepository>();
        }
        public Task<List<AuctionStateModel>> GetAllAuctionStates()
        {
            var list = _auctionStateRepository.Get().Include(_ => _.AuctionEvent).Include(_ => _.Orchid).ToListAsync().Result;
            var result = _mapper.Map<List<AuctionStateModel>>(list);
            return Task.FromResult(result);
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
                OrchidId = model.OrchidId,
                AuctionEventId = model.AuctionEventId
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
                entity.OrchidId = auctionState.OrchidId;
                entity.AuctionEventId = auctionState.AuctionEventId;

                _auctionStateRepository.Update(entity);
                UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }
        public Task<string> DeleteAuctionState(string id)
        {
            var entity = _auctionStateRepository.Get(_ => _.Id.Equals(id)).FirstOrDefault();
            if(entity == null)
            {
                return Task.FromResult("Not Found Auction State Need Delete");
            }
            entity.DeleteTime = DateTime.UtcNow;
            _auctionStateRepository.Update(entity); UnitOfWork.SaveChange();
            return Task.FromResult("Delete Auction State Successfully");
        }
        /* 
          public Task UpdateAuctionState(AuctionState auctionState)
          {
              throw new NotImplementedException();
          }
        */

        public Task<List<OrchidAuctionModel>> GetOrchidAuctions()
        {
            var listEntities = _auctionStateRepository.Get(null, false, _ => _.Orchid, _ => _.AuctionEvent, _ => _.DealHangers).ToList();
            var result = _mapper.Map<List<OrchidAuctionModel>>(listEntities);
            return Task.FromResult(result);
        }

        public Task<OrchidAuctionModel> GetOrchidAuction(string id)
        {
            var entity = _auctionStateRepository.Get(_ => _.Id == id, false, _ => _.Orchid, _ => _.AuctionEvent, _ => _.DealHangers).FirstOrDefault();
            var result = _mapper.Map<OrchidAuctionModel>(entity);
            return Task.FromResult(result);
        }
        

        public Task<string> CreateAuctionByOwner(AuctionRequestModel auctionRequest)
        {
            
                // Create a new AuctionEvent
                var auctionEvent = new AuctionEvent
                {
                    BeginDateTime = auctionRequest.BeginDateTime,
                    EndDateTime = auctionRequest.EndDateTime,
                    AuctionStatus = "Pending",
                    // Set other properties accordingly
                };

            // Create a new AuctionState for the Orchid
            var auctionState = new AuctionState
            {
                Position = 1,
                StartingPrice = auctionRequest.StartingPrice,
                ExpectedPrice = auctionRequest.ExpectedPrice,
                MinRaise = auctionRequest.MinRaise,
                MaxRaise = auctionRequest.MaxRaise,
                AuctionStateStatus = "HoldOn",
                FinalPrice = auctionRequest.FinalPrice,
                AuctionEventId = auctionEvent.Id,
                OrchidId = auctionRequest.orchidId
                // Set other properties accordingly
            };

                // Associate AuctionState with Orchid
               

                 _auctionEventRepository.Add(auctionEvent);
                 _auctionStateRepository.Add(auctionState);

                // Save changes asynchronously
                UnitOfWork.SaveChange();
            
            
            return Task.FromResult(auctionState.Id);
        }
    }
    
}

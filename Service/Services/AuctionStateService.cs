using Invedia.DI.Attributes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Models.AuctionStateModels;
using WebApp.Repository.Base;
using WebApp.Repository.Base.Interface;
using WebApp.Repository.Entities;
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
        public Task<List<AuctionState>> GetAllAuctionStates()
        {
            throw new NotImplementedException();
        }

        public Task<AuctionState> GetAuctionStateById(string id)
        {
            throw new NotImplementedException();
        }

        public Task CreateAuctionState(AuctionState auctionState)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAuctionState(AuctionState auctionState)
        {
            throw new NotImplementedException();
        }

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

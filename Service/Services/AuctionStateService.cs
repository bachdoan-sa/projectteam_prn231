using Invedia.DI.Attributes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Models.AuctionStateModels;
using WebApp.Repository.Entities;
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

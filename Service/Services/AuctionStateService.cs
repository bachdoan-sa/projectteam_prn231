using AngleSharp.Dom;
using EnumsNET;
using Invedia.DI.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.EnumCore;
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
        private readonly IDealHangerRepository _dealHangerRepository;
        private readonly IWalletRepository _walletrepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IOrderRepository _orderrepository;
        private readonly IOrchidsRepository _orchidsRepository;
        public AuctionStateService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _auctionStateRepository = serviceProvider.GetRequiredService<IAuctionStateRepository>();
            _auctionEventRepository = serviceProvider.GetRequiredService<IAuctionEventRepository>();
            _dealHangerRepository = serviceProvider.GetRequiredService<IDealHangerRepository>();
            _walletrepository = serviceProvider.GetRequiredService<IWalletRepository>();
            _orderDetailRepository = serviceProvider.GetRequiredService<IOrderDetailRepository>();
            _orderrepository = serviceProvider.GetRequiredService<IOrderRepository>();
            _orchidsRepository = serviceProvider.GetRequiredService<IOrchidsRepository>();
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
            if (entity == null)
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
            var entity = _auctionStateRepository.Get(_ => _.Id == id, false, _ => _.Orchid, _ => _.AuctionEvent, _ => _.DealHangers, _ => _.DealHangers).FirstOrDefault();
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
                AuctionStateStatus = AuctionStateEnum.Pending.AsString(),
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

        public Task<List<AuctionStateModel>> GetAuctionStateByStatusPending()
        {
            var listEntities = _auctionStateRepository.Get(_ => _.AuctionStateStatus.Equals("Pending")).ToListAsync().Result;
            var result = _mapper.Map<List<AuctionStateModel>>(listEntities);
            return Task.FromResult(result);
        }

        public Task<string> ChangeAuctionStatus(string auctionId)
        {
            var auction = _auctionStateRepository.Get(_ => _.Id.Equals(auctionId)).FirstOrDefault();
            if (auction == null)
            {
                return Task.FromResult("Not Found Auction Need Update");
            }

            var auction2 = _auctionEventRepository.Get(_ => _.Id.Equals(auction.AuctionEventId)).FirstOrDefault();
            if (auction2 == null)
            {
                return Task.FromResult("Not Found AuctionEvent Need Update");
            }


            auction.AuctionStateStatus = AuctionStateEnum.Active.AsString();
            auction.LastUpdated = DateTime.Now;
            auction2.AuctionStatus = AuctionEventEnum.Active.AsString();

            _auctionStateRepository.Update(auction);
            _auctionEventRepository.Update(auction2);
            UnitOfWork.SaveChange();
            return Task.FromResult(auction.Id);
        }

        public async Task<List<AuctionStateModel>> GetAuctionStateEnds()
        {
            var currentDateTime = DateTime.UtcNow;
            var listEntities = await _auctionStateRepository.Get(null, false, _ => _.Orchid, _ => _.AuctionEvent)
                .Where(a => a.AuctionStateStatus == "Active" &&
                            a.AuctionEvent.EndDateTime <= currentDateTime)
                .ToListAsync();

            var result = _mapper.Map<List<AuctionStateModel>>(listEntities);
            return result;
        }


        public async Task EndAuction(string auctionId)
        {

            // Update AuctionState
            var auctionState = await _auctionStateRepository.Get(a => a.Id == auctionId).FirstOrDefaultAsync();
            if (auctionState != null)
            {
                auctionState.AuctionStateStatus = "done";
            }
            else
            {
                throw new Exception("AuctionState not found");
            }
            // Update AuctionEvent
            var auctionEvent = await _auctionEventRepository.Get(a => a.Id == auctionState.AuctionEventId).FirstOrDefaultAsync();
            if (auctionEvent != null)
            {
                auctionEvent.AuctionStatus = "done";
                _auctionEventRepository.Update(auctionEvent);
            }
            else
            {
                throw new Exception("AuctionEvent not found");
            }

           

            // Update FinalPrice in AuctionState based on the maximum Currency in DealHanger
            var maxCurrencyDealHanger = await _dealHangerRepository.Get(d => d.AuctionStateId == auctionId)
                .OrderByDescending(d => d.Currency)
                .FirstOrDefaultAsync();
            if (maxCurrencyDealHanger != null)
            {
                // Update FinalPrice of AuctionState
                auctionState.FinalPrice = maxCurrencyDealHanger.Currency;
                _auctionStateRepository.Update(auctionState);

                // Update DealHanger
                maxCurrencyDealHanger.DealStatus = "win";
                _dealHangerRepository.Update(maxCurrencyDealHanger);

                // Update Wallet
                var wallet = await _walletrepository.Get(w => w.AccountId == maxCurrencyDealHanger.CustomerId).FirstOrDefaultAsync();
                if (wallet != null)
                {

                    wallet.Balance -= maxCurrencyDealHanger.Currency;
                    _walletrepository.Update(wallet);
                }
                else
                {
                    throw new Exception("Wallet not found");
                }

                // Find Orchid by OrchidId
                var orchid = await _orchidsRepository.Get(q => q.Id == auctionState.OrchidId).FirstOrDefaultAsync();
                if (orchid != null)
                {
                    // Update OrchidStatus to "Sold"
                    orchid.OrchidStatus = "Sold";
                    _orchidsRepository.Update(orchid);
                }
                else
                {
                    throw new Exception("Orchid not found");
                }

                // Create Order and OrderDetail
                var order = new Order
                {
                    Id = Guid.NewGuid().ToString(), 
                    Total = maxCurrencyDealHanger.Currency, 
                    OrderStatus = "Pending", 
                    CustomerId = maxCurrencyDealHanger.CustomerId, 
                    CreatedTime = DateTimeOffset.Now,
                    LastUpdated = DateTimeOffset.Now
                };

                _orderrepository.Add(order);

                // Create OrderDetail
                var orderDetail = new OrderDetail
                {
                    OrderDetailStatus = "Pending",
                    Cost = maxCurrencyDealHanger.Currency, 
                    OrderId = order.Id, 
                    OrchidId = auctionState.OrchidId, 
                    CreatedTime = DateTimeOffset.Now,
                    LastUpdated = DateTimeOffset.Now
                };
                
                _orderDetailRepository.Add(orderDetail);

                UnitOfWork.SaveChange();
            }
            else
            {
                throw new Exception("No DealHanger found for the auction");
            }
        }
    }

}




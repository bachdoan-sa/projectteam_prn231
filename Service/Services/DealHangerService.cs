using Invedia.DI.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Models.DeadHangerModels;
using WebApp.Repository.Base;
using WebApp.Repository.Entities;
using WebApp.Repository.Repositories;
using WebApp.Repository.Repositories.IRepositories;
using WebApp.Service.IServices;

namespace WebApp.Service.Services
{
    [ScopedDependency(ServiceType = typeof(IDealHangerService))]
    public class DealHangerService : Base.Service, IDealHangerService
    {
        private readonly IDealHangerRepository _repository;
        private readonly IWalletRepository _walletrepository;

        private readonly IAuctionStateRepository _auctionStaterepository;


        public DealHangerService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _repository = serviceProvider.GetRequiredService<IDealHangerRepository>();
            _walletrepository = serviceProvider.GetRequiredService<IWalletRepository>();
            _auctionStaterepository = serviceProvider.GetRequiredService<IAuctionStateRepository>(); ;
        }

        public Task<string> CreateDealHanger(DealHangerModel dealHanger)
        {


            var entity = new DealHanger
            {
                DealStatus = dealHanger.DealStatus,
                Currency = dealHanger.Currency,
                CustomerId = dealHanger.CustomerId,
                AuctionStateId = dealHanger.AuctionStateId
            };
            _repository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);

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
                existingDealHanger.DealStatus = dealHanger.DealStatus;
                existingDealHanger.Currency = dealHanger.Currency;

                _repository.Update(existingDealHanger);

            }
            return Task.FromResult(existingDealHanger.Id);
        }

        public async Task<string> StartAuction(DealHangerModel request)
        {
            var userWallet = await _walletrepository.Get(wallet => wallet.AccountId == request.CustomerId).FirstOrDefaultAsync();
            var listDeal = await _repository.Get(dealHanger => dealHanger.AuctionStateId == request.AuctionStateId).ToListAsync();
            double CurrentValue = 0;
            var a = await _auctionStaterepository.Get(a => a.Id == request.AuctionStateId).FirstOrDefaultAsync();
            if (!listDeal.IsNullOrEmpty())
            {
                CurrentValue = listDeal.Select(x => x.Currency).Max();
            }
            else
            {
                if (a != null)
                {
                    CurrentValue = a.StartingPrice ?? 0;
                }
            }
            // kiểm tra số dư trong tài khoản 
            if (double.Parse(userWallet.Balance) < request.Currency)
            {
                return "Số dư không đủ để đấu giá";
            }
            // kiểm tra min + giá sẵn có
            if (request.Currency < (CurrentValue + (a.MinRaise ?? 0)))
            {
                return "Số tiền ra giá phải lớn hơn Giá hiện tại cộng giá tăng tối thiểu";
            }
            //kiểm tra max + giá sẵn có
            if (a.MaxRaise != null)
            {
                if (request.Currency > CurrentValue + a.MaxRaise)
                {
                    return "Số tiền ra giá phải nhỏ hơn Giá hiện tại cộng giá tăng tối đa";
                }
            }
            var dealHanger = new DealHangerModel
            {
                DealStatus = "Active",
                Currency = request.Currency,
                CustomerId = request.CustomerId,
                AuctionStateId = request.AuctionStateId,
            };

            var createdDealHangerId = await CreateDealHanger(dealHanger);

            return $"Đấu giá thành công. DealHangerId: {createdDealHangerId}";
        }

        public Task<List<DealHangerHistoryModel>> GetByCustomerId(string id)
        {
            var dealHanger = _repository.Get(dealHanger => dealHanger.CustomerId == id)
                                        .Include(dealHanger => dealHanger.AuctionState)
                                        .ToListAsync().Result;
            var result = _mapper.Map<List<DealHangerHistoryModel>>(dealHanger);
            return Task.FromResult(result);
        }
    }
}



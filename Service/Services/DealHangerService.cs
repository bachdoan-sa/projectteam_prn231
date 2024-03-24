using AngleSharp.Dom;
using EnumsNET;
using Invedia.DI.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Constants;
using WebApp.Core.EnumCore;
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
                existingDealHanger.AuctionStateId = dealHanger.AuctionStateId;
                existingDealHanger.CustomerId = dealHanger.CustomerId;
                existingDealHanger.DealStatus = dealHanger.DealStatus;
                existingDealHanger.Currency = dealHanger.Currency;

                _repository.Update(existingDealHanger);
                UnitOfWork.SaveChange();
            }
            return Task.FromResult(existingDealHanger.Id);
        }

        public Task<string> StartAuction(DealHangerModel request)
        {
            request.CustomerId = GetSidLogged();
            //Lấy thông tin: Ví của người dùng. Danh sách Deal trong Buổi đấu giá với Id buổi.
            var userWallet =  _walletrepository.Get(wallet => wallet.AccountId == request.CustomerId).FirstOrDefault();
            var auctionListDeal =  _repository.Get(dealHanger => dealHanger.AuctionStateId == request.AuctionStateId).ToList();
            // Lấy giá tiền cao nhất của buổi đấu giá đó.
            double CurrentValue = 0;
            var a =  _auctionStaterepository.Get(a => a.Id == request.AuctionStateId).FirstOrDefault();
            if (!auctionListDeal.IsNullOrEmpty())
            {
                CurrentValue = auctionListDeal.Select(x => x.Currency).Max();
            }
            else
            {
                if (a != null)
                {
                    CurrentValue = a.StartingPrice ?? 0;
                }
            }
            // Kiểm tra xem User có các deal khác ĐANG đấu giá song song -> Nếu giá trị hơn tổng số tài sản thì không cho phép.
            var userlistDeal =  _repository.Get(dealHanger => dealHanger.CustomerId == request.CustomerId)
               .Where(_ => _.DealStatus == DealStatusEnum.OnRace.AsString()).Select(_ => _.Currency)
               .ToList();
            double allBalance = 0;
            if (!userlistDeal.IsNullOrEmpty())
            {
                foreach (var money in userlistDeal)
                {
                    allBalance = allBalance + money;
                }
            }
            // 1 kiểm tra số dư trong tài khoản 
            if (double.Parse(userWallet?.Balance ?? "0") < request.Currency)
            {
                return Task.FromResult("Số dư không đủ để đấu giá");
            } // 1.1 Kiểm tra số dư có chi đủ cho các cuộc đấu giá đang hoạt động hiện tại
            else if (double.Parse(userWallet?.Balance ?? "0") < (request.Currency + allBalance))
            {
                return Task.FromResult("Số dư không đủ để đấu giá, hãy kiểm tra lại danh sách đấu giá bạn đang tham gia)";
            }


            // 2 kiểm tra min + giá sẵn có
            if (request.Currency < (CurrentValue + (a.MinRaise ?? 0)))
            {
                return Task.FromResult("Số tiền ra giá phải lớn hơn Giá hiện tại cộng giá tăng tối thiểu");
            }
            // 3 kiểm tra max + giá sẵn có
            if (a.MaxRaise != null)
            {
                if (request.Currency > CurrentValue + a.MaxRaise)
                {
                    return Task.FromResult("Số tiền ra giá phải nhỏ hơn Giá hiện tại cộng giá tăng tối đa");
                }
            }

            // 4 Chuyển dealhanger onRace của Listdeal từ trước thành offRace
            foreach (var item in auctionListDeal.Where(_ => _.DealStatus == DealStatusEnum.OnRace.AsString()))
            {
                if (item != null)
                {
                    item.DealStatus = DealStatusEnum.OffRace.AsString();
                    _repository.Update(item);
                }
            }
            // 5 Tạo mới DealHanger và lưu vào database
            var dealHanger = new DealHanger
            {
                DealStatus = DealStatusEnum.OnRace.AsString(),
                Currency = request.Currency,
                CustomerId = request.CustomerId,
                AuctionStateId = request.AuctionStateId,
            };
            _repository.Add(dealHanger);
            UnitOfWork.SaveChange();

            return Task.FromResult($"Đấu giá thành công. DealHangerId: {dealHanger.Id}");
        }

        public Task<List<DealHangerHistoryModel>> GetByCustomerId(string id)
        {
            var dealHanger = _repository.Get(dealHanger => dealHanger.CustomerId == id)
                                        .Include(dealHanger => dealHanger.AuctionState)
                                        .ToListAsync().Result;
            var result = _mapper.Map<List<DealHangerHistoryModel>>(dealHanger);
            return Task.FromResult(result);
        }

        private string GetSidLogged()
        {
            var sid = _http.HttpContext?.User.FindFirst(ClaimTypes.Sid)?.Value;
            if (sid == null)
            {
                throw new Exception(ErrorCode.NotFound);
            }
            return sid;
        }
    }
}



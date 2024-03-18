using Invedia.DI.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Models.AuctionEventModels;
using WebApp.Repository.Entities;
using WebApp.Repository.Repositories;
using WebApp.Repository.Repositories.IRepositories;
using WebApp.Service.IServices;
using static WebApp.Core.Constants.WebApiEndpoint;

namespace WebApp.Service.Services
{
    [ScopedDependency(ServiceType = typeof(IAuctionEventService))]
    public class AuctionEventService : Base.Service,IAuctionEventService
	{
		private readonly IAuctionEventRepository _auctionEventRepository;
		public AuctionEventService(IServiceProvider serviceProvider) : base(serviceProvider)
		{
			_auctionEventRepository = serviceProvider.GetRequiredService<IAuctionEventRepository>();
		}
		public Task<string> CreateAuctionEvent(AuctionEventModel model)
		{
			var entity = new Repository.Entities.AuctionEvent
            {
				BeginDateTime = model.BeginDateTime,
				EndDateTime = model.EndDateTime,
				AuctionStatus = model.AuctionStatus,
				StaffId = model.StaffId
			};
			_auctionEventRepository.Add(entity);
			UnitOfWork.SaveChange();
			return Task.FromResult(entity.Id);
		}

		public Task<List<AuctionEventModel>> GetAllAuctionEvents()
		{
			var list = _auctionEventRepository.Get().ToListAsync().Result;
			var result = _mapper.Map<List<AuctionEventModel>>(list);
			return Task.FromResult(result);
		}

		public Task<AuctionEventModel> GetAuctionEventById(string id)
		{
			var entity = _auctionEventRepository.Get(_ => _.Id.Equals(id)).FirstOrDefault();
			var result = _mapper.Map<AuctionEventModel>(entity);
			return Task.FromResult(result);
		}

		public Task<string> UpdateAuctionEvent(AuctionEventModel auctionEventModel)
		{
            var entity = _auctionEventRepository.Get(_ => _.Id.Equals(auctionEventModel.Id)).FirstOrDefault();

            if (entity == null)
            {
                return Task.FromResult("Not Found Auction Event Need Update");
            }

            entity.BeginDateTime = auctionEventModel.BeginDateTime;
            entity.EndDateTime = auctionEventModel.EndDateTime;
            entity.AuctionStatus = auctionEventModel.AuctionStatus;
            entity.StaffId = auctionEventModel.StaffId;


            _auctionEventRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task<string> DeleteAuctionEvent(string id)
        {
            var entity = _auctionEventRepository.Get(_ => _.Id.Equals(id)).FirstOrDefault();
            if (entity == null)
            {
                return Task.FromResult("Not Found Auction Event Need Delete");
            }
            entity.DeleteTime = DateTime.UtcNow;
            _auctionEventRepository.Update(entity);
			UnitOfWork.SaveChange();
            return Task.FromResult("Delete Auction Event Successfully");
        }
    }
}

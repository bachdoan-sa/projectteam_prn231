using Invedia.DI.Attributes;
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
			var entity = new AuctionEvent
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
			var list = _auctionEventRepository.Get().ToList();
			var result = _mapper.Map<List<AuctionEventModel>>(list);
			return Task.FromResult(result);
		}

		public Task<AuctionEventModel> GetAuctionEventById(string id)
		{
			var entity = _auctionEventRepository.Get(_ => _.Id.Equals(id)).FirstOrDefault();
			var result = _mapper.Map<AuctionEventModel>(entity);
			return Task.FromResult(result);
		}

		public Task<string> UpdateAuctionEvent(AuctionEventModel model)
		{
			throw new NotImplementedException();
		}
	}
}

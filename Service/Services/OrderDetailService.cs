using Invedia.DI.Attributes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Repository.Entities;
using WebApp.Repository.Repositories.IRepositories;
using WebApp.Service.IServices;
using WebApp.Core.Models.OrderDetailModels;
using Microsoft.Extensions.DependencyInjection;

namespace WebApp.Service.Services
{
    [ScopedDependency(ServiceType = typeof(IOrderDetailService))]
    public class OrderDetailService :Base.Service, IOrderDetailService  
    {
        private readonly IOrderDetailRepository _repository;

        public OrderDetailService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _repository = serviceProvider.GetRequiredService<IOrderDetailRepository>();

        }

        public Task<OrderDetail> CreateOrderDetail(OrderDetail orderDetail)
        {
            var createOrderDetail = _repository.Add(orderDetail);
            return Task.FromResult(createOrderDetail);
        }

        public Task<List<OrderDetail>> GetAllOrderDetails()
        {
            var list = _repository.Get().ToListAsync();
            return list;
        }

        public Task<OrderDetail?> GetOrderDetailById(string id)
        {
            var OrderDetail = _repository.Get(orderDetail => orderDetail.Id == id).FirstOrDefaultAsync();
            return OrderDetail;
        }

        public Task<string> UpdateOrderDetail(OrderDetail orderDetail)
        {
            var existingOrderDetail = _repository.GetSingle(x => x.Id == orderDetail.Id);

            if (existingOrderDetail != null)
            {
                existingOrderDetail.Cost = orderDetail.Cost;
                existingOrderDetail.OrderDetailStatus = orderDetail.OrderDetailStatus;

                _repository.Update(existingOrderDetail);

            }
            return Task.FromResult(existingOrderDetail.Id);
        }

        public Task<List<OrderDetailModel>> GetByOrderId(string id)
        {
            var orderDetail = _repository.Get(orderDetail => orderDetail.OrderId == id)
                                        .Include(orderDetail => orderDetail.Orchid).ToListAsync().Result;
            var result = _mapper.Map<List<OrderDetailModel>>(orderDetail);
            return Task.FromResult(result);
        }
    }
}


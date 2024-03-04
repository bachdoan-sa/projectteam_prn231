using Invedia.DI.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Models.OrderModels;
using WebApp.Repository.Base;
using WebApp.Repository.Base.Interface;
using WebApp.Repository.Entities;
using WebApp.Repository.Repositories;
using WebApp.Repository.Repositories.IRepositories;
using WebApp.Service.IServices;

namespace WebApp.Service.Services
{
    [ScopedDependency(ServiceType = typeof(IOrderService))]
    public class OrderService : Base.Service, IOrderService
    {

        private readonly IOrderRepository _repository;

        public OrderService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _repository = serviceProvider.GetRequiredService < IOrderRepository>();

        }

        public Task<string> CreateOrder(OrderModel model)
        {
            var order = new Order();
            order.Total = model.Total ?? 0;
            order.OrderStatus = model.OrderStatus;
            order.CustomerId = model.CustomerId;

            _repository.Add(order);
            UnitOfWork.SaveChange();
            return Task.FromResult(order.Id); 
        }

        public Task<List<Order>> GetAllOrders()
        {
            var list = _repository.Get().ToListAsync();
            return list;
        }

        public Task<Order?> GetOrderById(string id)
        {
            var order = _repository.Get(order => order.Id == id).FirstOrDefaultAsync();
            return order;
        }

        public Task<string> UpdateOrder(OrderModel model)
        {
            var existingOrder = _repository.GetSingle(x => x.Id == model.Id);

            if (existingOrder != null)
            {


                existingOrder.Total = model.Total ?? 0;
                existingOrder.OrderStatus = model.OrderStatus;
                existingOrder.CustomerId = model.CustomerId;

                
               _repository.Update(existingOrder);
                UnitOfWork.SaveChange();

            }
            return Task.FromResult(existingOrder.Id);
        }
    }
}

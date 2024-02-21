using Invedia.DI.Attributes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Repository.Entities;
using WebApp.Repository.Repositories;
using WebApp.Repository.Repositories.IRepositories;
using WebApp.Service.IServices;

namespace WebApp.Service.Services
{
    [ScopedDependency(ServiceType = typeof(IOrderService))]
    public class OrderService : IOrderService
    {

        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;

        }

        public Task<Order> CreateOrder(Order order)
        {
            var createOrder = _repository.Add(order);
            return Task.FromResult(createOrder); 
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

        public Task<string> UpdateOrder(Order order)
        {
            var existingOrder = _repository.GetSingle(x => x.Id == order.Id);

            if (existingOrder != null)
            {


                existingOrder.Total = order.Total;
                existingOrder.OrderStatus = order.OrderStatus;
                existingOrder.CustomerId = order.CustomerId;

                
               _repository.Update(existingOrder);
                
            }
            return Task.FromResult(existingOrder.Id);
        }
    }
}

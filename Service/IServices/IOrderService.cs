using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Repository.Entities;

namespace WebApp.Service.IServices
{
    public interface IOrderService
    {
        public Task<List<Order>> GetAllOrders();
        public Task<Order> GetOrderById(string id);
        public Task<Order> CreateOrder(Order order);
        public Task<string> UpdateOrder(Order order);
    }
}

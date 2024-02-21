using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Repository.Entities;

namespace WebApp.Service.IServices
{
    public interface IOrderDetailService
    {
        public Task<List<OrderDetail>> GetAllOrderDetails();
        public Task<OrderDetail> GetOrderDetailById(string id);
        public Task<OrderDetail> CreateOrderDetail(OrderDetail orderDetail);
        public Task<string> UpdateOrderDetail(OrderDetail orderDetail);
    }
}

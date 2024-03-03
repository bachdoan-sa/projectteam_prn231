using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Core.Models.OrderModel
{
    public class OrderModel
    {
        public string? Id { get; set; }
        public double? Total { get; set; }
        public string? OrderStatus { get; set; }
        public string? CustomerId { get; set; }
        public DateTimeOffset? CreatedTime { get; set; }
        public DateTimeOffset? LastUpdated { get; set; }
        public DateTimeOffset? DeleteTime { get; set; }
    }
}

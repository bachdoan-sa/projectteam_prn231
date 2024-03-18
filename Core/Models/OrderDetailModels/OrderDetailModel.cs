using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Models.OrchidModels;

namespace WebApp.Core.Models.OrderDetailModels
{
    public class OrderDetailModel
    {
        public string? OrderDetailStatus { get; set; }
        public double? Cost { get; set; }
        public string? OrderId { get; set; }
        public string? OrchidId { get; set; }
        public OrchidModel? Orchid { get; set; } 
        public DateTimeOffset? CreatedTime { get; set; }
        public DateTimeOffset? LastUpdated { get; set; }
        public DateTimeOffset? DeleteTime { get; set; }

    }
}

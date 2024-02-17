using Repository.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Repository.Entities
{
    public class OrderDetail : BaseEntityModel
    {
        public string OrderDetailStatus { get; set; }
        public double Cost { get; set; }

        public string? OrderId { get; set; }
        [ForeignKey(nameof(OrderId))]
        public virtual Order Order { get; set; }
        public string? OrchidId { get; set; }
        [ForeignKey(nameof(OrchidId))]
        public virtual Orchid? Orchid { get; set; }
    }
}

using WebApp.Repository.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Repository.Entities
{
    public class Order : BaseEntityModel
    {
        public double Total { get; set; }
        public string OrderStatus { get; set; }

        public string? CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public virtual Account Account { get; set; }
        public virtual ICollection<OrderDetail>? OrderDetails { get; set; }
        /*public virtual ICollection<Transaction>? Transactions { get; set; }*/
    }
}

using WebApp.Repository.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Repository.Entities
{
    public class Orchid : BaseEntityModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string OrchidStatus { get; set; }

        public string? OrchidCategoryId { get; set; }
        [ForeignKey(nameof(OrchidCategoryId))]
        public virtual OrchidCategory OrchidCategory { get; set; }

        
        public string? ProductOwnerId { get; set; }
        [ForeignKey(nameof(ProductOwnerId))]
        public virtual Account Account { get; set; }

        public virtual ICollection<OrchidMutation>? OrchidMutations { get; set; }
        public virtual ICollection<AuctionState>? AuctionStates { get; set; }
        public virtual ICollection<OrderDetail>? OrderDetails { get; set; }
        public virtual ICollection<OrchidImage>? OrchidImages { get; set; }
    }
}

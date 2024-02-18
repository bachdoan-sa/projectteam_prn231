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
    public class DealHanger : BaseEntityModel
    {
        public string DealStatus { get; set; }
        public double Currency { get; set; }
       
        public string CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public virtual Account? Account { get; set; }
        
        public string AuctionStateId { get; set; }
        [ForeignKey(nameof(AuctionStateId))]
        public virtual AuctionState? AuctionState { get; set; }
    }
}

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
    public class AuctionState : BaseEntityModel
    {
        public int Position { get; set; }
        public double? StartingPrice { get; set; }
        public double?   ExpectedPrice { get; set; }
        public double? MinRaise { get; set; }
        public double? MaxRaise { get; set; }
        public string AuctionStateStatus { get; set; }
        public double? FinalPrice { get; set; }

        public string? OrchidId { get; set; }
        [ForeignKey(nameof(OrchidId))]
        public virtual Orchid? Orchid { get; set; }

        
        public string? AuctionEventId { get; set; }
        [ForeignKey(nameof(AuctionEventId))]
        public virtual AuctionEvent? AuctionEvent { get; set; }
        public virtual ICollection<DealHanger>? DealHangers { get; set;}
    }
}

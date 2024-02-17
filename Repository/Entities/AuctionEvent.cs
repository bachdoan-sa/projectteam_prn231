using Repository.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class AuctionEvent : BaseEntityModel
    {
        public DateTime? BeginDateTime { get; set; }
        public DateTime? EndDateTime { get; set;}
        public string AuctionStatus { get; set; }

        public string? StaffId { get; set; }
        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }
        public virtual ICollection<AuctionState>? AuctionStates { get; set; }
    }
}

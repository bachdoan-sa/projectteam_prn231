using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Core.Models.AuctionEventModel
{
    public class AuctionEventModel
    {
        public DateTime? BeginDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public string? AuctionStatus { get; set; }
        public string? StaffId { get; set; }
    }
}

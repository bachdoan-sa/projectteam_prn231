using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Core.Models.DeadHangerModels
{
    public class DealHangerModel
    {
        public string DealStatus { get; set; }
        public double Currency { get; set; }

        public string CustomerId { get; set; }
        public string AuctionStateId { get; set; }
    }
}

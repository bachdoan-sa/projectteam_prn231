using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Models.AuctionEventModels;
using WebApp.Core.Models.DeadHangerModels;
using WebApp.Core.Models.OrchidModels;

namespace WebApp.Core.Models.AuctionStateModels
{
    public class OrchidAuctionModel
    {
        public string Id { get; set; }
        public int Position { get; set; }
        public double? StartingPrice { get; set; }
        public double? ExpectedPrice { get; set; }
        public double? MinRaise { get; set; }
        public double? MaxRaise { get; set; }
        public string AuctionStateStatus { get; set; }
        public double? FinalPrice { get; set; }
        public string? OrchidId { get; set; }
        public OrchidModel? Orchid { get; set; }
        public string? AuctionEventId { get; set; }
        public AuctionEventModel? AuctionEvent { get; set; }
        public ICollection<DealHangerModel>? DealHangers { get; set; }
    }
}

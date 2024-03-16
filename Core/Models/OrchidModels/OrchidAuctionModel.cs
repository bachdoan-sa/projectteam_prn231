using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Models.AuctionStateModels;

namespace WebApp.Core.Models.Orchid
{
    public class OrchidAuctionModel
    {
        public string? Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string? OrchidStatus { get; set; }
        public string? OrchidCategoryId { get; set; }
        public string? ProductOwnerId { get; set; }
        public ICollection<AuctionStateModel>? AuctionStates { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Models.AccountModels;
using WebApp.Core.Models.AuctionStateModels;

namespace WebApp.Core.Models.DeadHangerModels
{
    public class DealHangerHistoryModel
    {
        public string? Id { get; set; }
        public DateTimeOffset? CreatedTime { get; set; }
        public DateTimeOffset? LastUpdated { get; set; }
        public DateTimeOffset? DeleteTime { get; set; }
        public string? DealStatus { get; set; }
        public long? Currency { get; set; }
        public string? CustomerId { get; set; }
        public AccountModel? Account { get; set; }
        public string? AuctionStateId { get; set; }
        public AuctionStateModel? AuctionState { get; set; }
    }
}

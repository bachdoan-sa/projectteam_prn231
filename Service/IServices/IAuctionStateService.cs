using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Models.AuctionStateModels;
using WebApp.Repository.Entities;

namespace WebApp.Service.IServices
{
    public interface IAuctionStateService
    {
        Task<List<AuctionState>> GetAllAuctionStates();
        Task<AuctionState> GetAuctionStateById(string id);
        Task CreateAuctionState(AuctionState auctionState);
        Task UpdateAuctionState(AuctionState auctionState);
        Task<List<OrchidAuctionModel>> GetOrchidAuctions();
        Task<OrchidAuctionModel> GetOrchidAuction(string id);
    }
}

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
        Task<List<AuctionStateModel>> GetAllAuctionStates();
        Task<AuctionStateModel> GetAuctionStateById(string id);
        Task<string> CreateAuctionState(AuctionStateModel auctionState);
        Task<string> UpdateAuctionState(AuctionStateModel auctionState);
        public Task<string> DeleteAuctionState(string id);
        Task<List<OrchidAuctionModel>> GetOrchidAuctions();
        Task<OrchidAuctionModel> GetOrchidAuction(string id);
        Task<string> CreateAuctionByOwner(AuctionRequestModel auctionRequest);
        Task<List<AuctionStateModel>> GetAuctionStateByStatusPending();
        Task<string> ChangeAuctionStatus(string auctionId);
        Task<List<AuctionStateModel>> GetAuctionStateEnds();
        Task EndAuction(string auctionId);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Models.AuctionEventModels;
using WebApp.Repository.Entities;

namespace WebApp.Service.IServices
{
    public interface IAuctionEventService
    {
        Task<List<AuctionEventModel>> GetAllAuctionEvents();
        Task<AuctionEventModel> GetAuctionEventById(string id);
        Task<string> CreateAuctionEvent(AuctionEventModel  model);
        Task<string> UpdateAuctionEvent(AuctionEventModel model);
        public Task<string> DeleteAuctionEvent(string id);


    }
}

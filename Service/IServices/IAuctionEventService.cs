using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Repository.Entities;

namespace WebApp.Service.IServices
{
    public interface IAuctionEventService
    {
        Task<List<AuctionEvent>> GetAllAuctionEvents();
        Task<AuctionEvent> GetAuctionEventById(string id);
        Task CreateAuctionEvent(AuctionEvent  auctionEvent);
        Task UpdateAuctionEvent(AuctionEvent auctionEvent);
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Repository.Entities;
using WebApp.Service.IServices;
using WebApp.Service.Services;
using static WebApp.Core.Constants.WebApiEndpoint;

namespace WebApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionEventController : ControllerBase
    {
        private readonly IAuctionEventService _auctionEventService;
        public AuctionEventController(IAuctionEventService auctionEventService)
        {
            _auctionEventService = auctionEventService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Repository.Entities.AuctionEvent>>> GetAllAuctionEvents()
        {
            var auctionEvents = await _auctionEventService.GetAllAuctionEvents();
            return Ok(auctionEvents);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Repository.Entities.AuctionEvent>> GetAuctionEventById(string id)
        {
            var auctionEvent = await _auctionEventService.GetAuctionEventById(id);
            if (auctionEvent == null)
            {
                return NotFound();
            }
            return Ok(auctionEvent);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAuctionEvent(Repository.Entities.AuctionEvent auctionEvent)
        {
            await _auctionEventService.CreateAuctionEvent(auctionEvent);
            return Ok();
        }
    }
}

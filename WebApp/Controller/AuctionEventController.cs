using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Core.Constants;
using WebApp.Core.Models.AuctionEventModels;
using WebApp.Repository.Entities;
using WebApp.Service.IServices;
using WebApp.Service.Services;
using static WebApp.Core.Constants.WebApiEndpoint;

namespace WebApp.Controller
{
    [ApiController]
    public class AuctionEventController : ControllerBase
    {
        private readonly IAuctionEventService _auctionEventService;
        public AuctionEventController(IAuctionEventService auctionEventService)
        {
            _auctionEventService = auctionEventService;
        }
        [Route(WebApiEndpoint.AuctionEvent.GetAllAuctionEvent)]
        [HttpGet]
        public async Task<IActionResult> GetAllAuctionEvents()
        {
            var auctionEvents = await _auctionEventService.GetAllAuctionEvents();
            return Ok(auctionEvents);
        }
        [Route(WebApiEndpoint.AuctionEvent.GetAuctionEvent)]
        [HttpGet]
        public async Task<IActionResult> GetAuctionEventById(string id)
        {
            var auctionEvent = await _auctionEventService.GetAuctionEventById(id);
            if (auctionEvent == null)
            {
                return NotFound();
            }
            return Ok(auctionEvent);
        }
        [Route(WebApiEndpoint.AuctionEvent.AddAuctionEvent)]
        [HttpPost]
        public async Task<IActionResult> CreateAuctionEvent(AuctionEventModel model)
        {
            var a = await _auctionEventService.CreateAuctionEvent(model);
            return Ok(a);
        }
        [Route(WebApiEndpoint.AuctionEvent.UpdateAuctionEvent)]
        [HttpPut]
        public async Task<IActionResult> UpdateAuctionState(string id, AuctionEventModel auctionStateModel)
        {
            if (!ModelState.IsValid)
            {
                return Ok(ModelState.ToList());
            }
            if (!id.Equals(auctionStateModel.Id))
            {
                return BadRequest();
            }
            var flag = await _auctionEventService.UpdateAuctionEvent(auctionStateModel);
            if (flag == null)
            {
                return NotFound();
            }
            return Ok(flag);
        }
    }
}

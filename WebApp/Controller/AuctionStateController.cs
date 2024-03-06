using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Core.Constants;
using WebApp.Core.Models.AuctionStateModels;
using WebApp.Repository.Entities;
using WebApp.Service.IServices;
using WebApp.Service.Services;
using static WebApp.Core.Constants.WebApiEndpoint;

namespace WebApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionStateController : ControllerBase
    {
        private readonly IAuctionStateService _stateService;
        public AuctionStateController(IAuctionStateService stateService)
        {
            _stateService = stateService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Repository.Entities.AuctionState>>> GetAllAuctionStates()
        {
            var auctionStates = await _stateService.GetAllAuctionStates();
            return Ok(auctionStates);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Repository.Entities.AuctionState>> GetAuctionStateById(string id)
        {
            var auctionState = await _stateService.GetAuctionStateById(id);
            if (auctionState == null)
            {
                return NotFound();
            }
            return Ok(auctionState);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAuctionState(Repository.Entities.AuctionState auctionState)
        {
            await _stateService.CreateAuctionState(auctionState);
            return Ok();
        }
        [Route(WebApiEndpoint.AuctionState.GetOrchidAuctions)]
        [HttpGet]
        public async Task<IActionResult> GetOrchidAuctions()
        {

            return Ok(await _stateService.GetOrchidAuctions());
        }
        [Route(WebApiEndpoint.AuctionState.GetOrchidAuction)]
        [HttpGet]
        public async Task<IActionResult> GetOrchidAuction(string id)
        {

            return Ok(await _stateService.GetOrchidAuction(id));
        }

        [HttpPost("CreateAuctionByOwner")]
        public async Task<ActionResult> CreateAuctionByOwner(AuctionRequestModel model)
        {
            return Ok(await _stateService.CreateAuctionByOwner(model));
        }
    }
}

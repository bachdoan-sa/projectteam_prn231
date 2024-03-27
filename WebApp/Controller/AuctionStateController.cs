using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
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
        [Route(WebApiEndpoint.AuctionState.GetAllAuctionState)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuctionStateModel>>> GetAllAuctionStates()
        {
            var auctionStates = await _stateService.GetAllAuctionStates();
            return Ok(auctionStates);
        }
        [Route(WebApiEndpoint.AuctionState.GetAuctionState)]
        [HttpGet]
        public async Task<IActionResult> GetAuctionStateById(string id)
        {
            var auctionState = await _stateService.GetAuctionStateById(id);
            if (auctionState == null)
            {
                return NotFound();
            }
            return Ok(auctionState);
        }
        [Route(WebApiEndpoint.AuctionState.AddAuctionState)]
        [HttpPost]
        public async Task<IActionResult> CreateAuctionState(AuctionStateModel auctionStateModel)
        {
            if (!ModelState.IsValid)
            {
                return Ok(ModelState.ToList());
            }
            var flag = await _stateService.CreateAuctionState(auctionStateModel);
            return Ok(flag);
        }
        [Route(WebApiEndpoint.AuctionState.UpdateAuctionState)]
        [HttpPut]
        public async Task<IActionResult> UpdateAuctionState(AuctionStateModel auctionStateModel)
        {
            if (!ModelState.IsValid)
            {
                return Ok(ModelState.ToList());
            }

            var flag = await _stateService.UpdateAuctionState(auctionStateModel);
            if (flag == null)
            {
                return NotFound();
            }
            return Ok(flag);
        }
        [Authorize(Roles = UserRole.ADMIN)]
        [Route(WebApiEndpoint.AuctionState.DeleteAuctionState)]
        [HttpDelete]
        public async Task<IActionResult> DeleteAuctionState(string id)
        {
            var flag = await _stateService.DeleteAuctionState(id);
            return Ok(flag);
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

        [Route(WebApiEndpoint.AuctionState.CreateAuctionByOwner)]
        [HttpPost]
        public async Task<ActionResult> CreateAuctionByOwner(AuctionRequestModel model)
        {
            return Ok(await _stateService.CreateAuctionByOwner(model));
        }
        [Route(WebApiEndpoint.AuctionState.GetAuctionStateByStatusPending)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Repository.Entities.AuctionState>>> GetAuctionStateByStatusPending()
        {
            var auctionStates = await _stateService.GetAuctionStateByStatusPending();
            return Ok(auctionStates);
        }
        [Authorize(Roles = UserRole.ADMIN)]
        [Route(WebApiEndpoint.AuctionState.ChangeAuctionStatus)]
        [HttpPut]
        public async Task<IActionResult> ChangeAuctionStatus(string id)
        {
            var result = await _stateService.ChangeAuctionStatus(id);
            if (result == "Not Found Auction Need Update")
            {
                return NotFound(result);
            }
            else
            {
                return Ok(result);
            }
        }

        [Route(WebApiEndpoint.AuctionState.GetAuctionStateEnds)]
        [HttpGet]
        public async Task<ActionResult<List<AuctionStateModel>>> GetAuctionStateEnds()
        {
            var activeAuctionStates = await _stateService.GetAuctionStateEnds();
            return Ok(activeAuctionStates);
        }

        [Route(WebApiEndpoint.AuctionState.EndAuction)]
        [HttpPost]
        public async Task<IActionResult> EndAuction(string id)
        {
            try
            {
                await _stateService.EndAuction(id);
                return Ok("Auction ended successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while ending the auction: {ex.Message}");
            }
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Core.Constants;
using WebApp.Core.Models.DeadHangerModels;
using WebApp.Repository.Entities;
using WebApp.Service.IServices;
using WebApp.Service.Services;

namespace WebApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealHangerController : ControllerBase
    {
        private readonly IDealHangerService _iDealHangerService;
        public DealHangerController(IDealHangerService iDealHangerService)
        {
            _iDealHangerService = iDealHangerService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await _iDealHangerService.GetAllDealhangers();

            return Ok(list);
        }
        [Route(WebApiEndpoint.DealHanger.GetDealHanger)]
        [HttpGet]
        public async Task<IActionResult> GetById(string id)
        {
            var dealHanger = await _iDealHangerService.GetDealHangerById(id);
            if (dealHanger == null)
            {
                return NotFound();
            }
            return Ok(dealHanger);
        }
        [Authorize(Roles = UserRole.ADMIN)]
        [Route(WebApiEndpoint.DealHanger.Post)]
        [HttpPost]
        public async Task<IActionResult> Post(DealHangerModel dealHanger)
        {
            var createdDealHangerId = await _iDealHangerService.CreateDealHanger(dealHanger);
            return CreatedAtAction(nameof(GetById), new { id = createdDealHangerId }, new { Id = createdDealHangerId });
        }
        [Authorize(Roles = UserRole.ADMIN)]
        [Route(WebApiEndpoint.DealHanger.Update)]
        [HttpPut]
        public async Task<IActionResult> Put(DealHanger dealHanger)
        {
            var result = await _iDealHangerService.UpdateDealHanger(dealHanger);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [Authorize(Roles = "CUSTOMER,PRODUCTOWER")]
        [Route(WebApiEndpoint.DealHanger.RaisePrice)]
        [HttpPost]
        public async Task<IActionResult> StartAuction(DealHangerModel request)
        {
            try
            {
                string result = await _iDealHangerService.StartAuction(request);
                return Ok(result); // Return success message
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Return error message
            }

        }
        [Authorize(Roles = "CUSTOMER,PRODUCTOWER")]
        [HttpGet("Customer")]
        public async Task<IActionResult> GetByCustomerId()
        {
            var dealHanger = await _iDealHangerService.GetByCustomerId();
            if (dealHanger == null)
            {
                return NotFound();
            }
            return Ok(dealHanger);
        }
    }
}
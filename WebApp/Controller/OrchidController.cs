using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Core.Constants;
using WebApp.Core.Models.OrchidModels;
using WebApp.Repository.Entities;
using WebApp.Service.IServices;
using WebApp.Service.Services;

namespace WebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrchidsController : ControllerBase
    {
        private readonly IOrchidsService _orchidsService;

        public OrchidsController(IOrchidsService orchidsService)
        {
            _orchidsService = orchidsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orchid>>> GetAllOrchids()
        {
            var orchids = await _orchidsService.GetAllOrchids();
            return Ok(orchids);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Orchid>> GetOrchidById(string id)
        {
            var orchid = await _orchidsService.GetOrchidById(id);
            if (orchid == null)
            {
                return NotFound();
            }
            return Ok(orchid);
        }

        [HttpPost]
        public async Task<ActionResult> AddOrchid(OrchidModel orchid)
        {
            await _orchidsService.AddOrchid(orchid);
            return Ok(orchid);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrchid(string id, Orchid orchid)
        {
            if (id != orchid.Id)
            {
                return BadRequest();
            }

            await _orchidsService.UpdateOrchid(orchid);
            return Ok();
        }

        [HttpGet("Owner/{id}")]
        public async Task<ActionResult<List<OrchidModel>>> GetOrchidsByProductOwnerId(string id)
        {
            var orchids = await _orchidsService.GetOrchidByProductOwnerId(id);
            if (orchids == null)
            {
                return NotFound();
            }
            return orchids;
        }

    }
}
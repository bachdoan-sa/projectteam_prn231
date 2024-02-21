using Microsoft.AspNetCore.Mvc;
using WebApp.Repository.Entities;
using WebApp.Service.IServices;
using WebApp.Service.Services;

namespace WebApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrchidsMutationController : ControllerBase
    {
        private readonly IOrchidMutationService _orchidMutationService;
        public OrchidsMutationController(IOrchidMutationService orchidMutationService)
        {
            _orchidMutationService = orchidMutationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrchidMutation()
        {
            var mutations = await _orchidMutationService.GetAllOrchidMutation();
            return Ok(mutations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrchidMutationById(string id)
        {
            var mutation = await _orchidMutationService.GetOrchidMutationById(id);
            if (mutation == null)
            {
                return NotFound();
            }
            return Ok(mutation);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrchidMutation(OrchidMutation orchidmutation)
        {
            await _orchidMutationService.AddOrchidMutaion(orchidmutation);
            return CreatedAtAction(nameof(GetOrchidMutationById), new { id = orchidmutation.Id }, orchidmutation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrchidMutation(string id, OrchidMutation orchidmutation)
        {
            if (id != orchidmutation.Id)
            {
                return BadRequest();
            }

            await _orchidMutationService.UpdateOrchidMutaion(orchidmutation);
            return Ok(orchidmutation);
        }
    }
}
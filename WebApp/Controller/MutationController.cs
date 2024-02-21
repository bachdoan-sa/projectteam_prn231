using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApp.Repository.Entities;
using WebApp.Service.IServices;

namespace WebApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MutationController : ControllerBase
    {
        private readonly IMutationService _mutationService;
        public MutationController(IMutationService mutationService)
        {
            _mutationService = mutationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mutation>>> GetAllMutations()
        {
            var mutations = await _mutationService.GetAllMutations();
            return Ok(mutations);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Mutation>> GetMutationById(string id)
        {
            var mutation = await _mutationService.GetMutationById(id);  
            if(mutation == null)
            {
                return NotFound();
            }
            return Ok(mutation);
        }

        [HttpPost]
        public async Task<ActionResult> CreateMutation(Mutation mutation)
        {
            await _mutationService.CreateMutaion(mutation); 
            return Ok();
        }

        //[HttpPut ("{id}")]
        //public async Task<ActionResult> UpdateMutation(string id, Mutation mutation)
        //{
        //    if(id != mutation.Id)
        //    {

        //    }
        //}

     }
}

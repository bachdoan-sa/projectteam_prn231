using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApp.Core.Constants;
using WebApp.Core.Models.MutationModels;
using WebApp.Repository.Entities;
using WebApp.Service.IServices;
using WebApp.Service.Services;

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

        [Route(WebApiEndpoint.Mutation.GetAllMutation)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mutation>>> GetAllMutations()
        {
            var mutations = await _mutationService.GetAllMutations();
            return Ok(mutations);
        }
        [Route(WebApiEndpoint.Mutation.GetMutation)]
        [HttpGet]
        public async Task<ActionResult<Mutation>> GetMutationById(string id)
        {
            var mutation = await _mutationService.GetMutationById(id);  
            if(mutation == null)
            {
                return NotFound();
            }
            return Ok(mutation);
        }
        [Route(WebApiEndpoint.Mutation.AddMutation)]
        [HttpPost]
        public async Task<ActionResult> CreateMutation(MutationModel model)
        {
            var newMutation = await _mutationService.CreateMutaion(model); 
            return Ok(newMutation);
        }
        [Route(WebApiEndpoint.Mutation.UpdateMutation)]
        [HttpPut]
        public async Task<ActionResult> UpdateMutation(MutationModel mutation)
        {
            if (!ModelState.IsValid)
            {
                return Ok(ModelState.ToList());
            }
            var flag = await _mutationService.UpdateMutaion(mutation);
            if (flag == null)
            {
                return NotFound();
            }
            return Ok(flag);
        }
        [Route(WebApiEndpoint.Mutation.DeleteMutation)]
        [HttpDelete]
        public async Task<IActionResult> DeleteMutation(string id) 
        {
            var flag = _mutationService.DeleteMutaion(id);
            return Ok(flag);
        }

    }
}

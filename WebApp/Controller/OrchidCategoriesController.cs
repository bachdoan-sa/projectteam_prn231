using Microsoft.AspNetCore.Mvc;
using WebApp.Core.Constants;
using WebApp.Repository.Entities;
using WebApp.Service.IServices;

namespace WebApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrchidCategoriesController : ControllerBase
    {
        private readonly IOrchidCategoriesService _orchidCategoriesService;

        public OrchidCategoriesController(IOrchidCategoriesService orchidCategoriesService)
        {
            _orchidCategoriesService = orchidCategoriesService;
        }

        [Route(WebApiEndpoint.OrchidCategory.GetAllOrchidCategory)]
        [HttpGet]
        public async Task<IActionResult> GetAllOrchidCategories()
        {
            var categories = await _orchidCategoriesService.GetAllOrchidCategorys();
            return Ok(categories);
        }

        [Route(WebApiEndpoint.OrchidCategory.GetOrchidCategory)]
        [HttpGet]
        public async Task<IActionResult> GetOrchidCategoryById(string id)
        {
            var category = await _orchidCategoriesService.GetOrchidCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [Route(WebApiEndpoint.OrchidCategory.AddOrchidCategory)]
        [HttpPost]
        public async Task<IActionResult> AddOrchidCategory(OrchidCategory orchidCategory)
        {
             var result = await _orchidCategoriesService.AddOrchidCategory(orchidCategory);
            return CreatedAtAction(nameof(GetOrchidCategoryById), new { id = result.Id }, result);
        }

        [Route(WebApiEndpoint.OrchidCategory.UpdateOrchidCategory)]
        [HttpPut]
        public async Task<IActionResult> UpdateOrchidCategory( OrchidCategory orchidCategory)
        {
            
            await _orchidCategoriesService.UpdateOrchidCategory(orchidCategory);
            return Ok(orchidCategory);
        }
    }
}
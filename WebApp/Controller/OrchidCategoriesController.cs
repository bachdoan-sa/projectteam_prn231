using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public async Task<IActionResult> GetAllOrchidCategories()
        {
            var categories = await _orchidCategoriesService.GetAllOrchidCategorys();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrchidCategoryById(string id)
        {
            var category = await _orchidCategoriesService.GetOrchidCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrchidCategory(OrchidCategory orchidCategory)
        {
            await _orchidCategoriesService.AddOrchidCategory(orchidCategory);
            return CreatedAtAction(nameof(GetOrchidCategoryById), new { id = orchidCategory.Id }, orchidCategory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrchidCategory(string id, OrchidCategory orchidCategory)
        {
            if (id != orchidCategory.Id)
            {
                return BadRequest();
            }

            await _orchidCategoriesService.UpdateOrchidCategory(orchidCategory);
            return Ok(orchidCategory);
        }
    }
}
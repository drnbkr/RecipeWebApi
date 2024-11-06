using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly IServiceManager _servicemanager;
        public CategoriesController(IServiceManager manager)
        {
            _servicemanager = manager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            var categories = await _servicemanager.CategoryService.GetAllCategoriesAsync(trackChanges: false);

            return Ok(categories);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneCategoryAsync([FromRoute(Name = "id")] int id)
        {
            var category = await _servicemanager.CategoryService.GetOneCategoryByIdAsync(id, trackChanges: false);

            return Ok(category);
        }


    }
}
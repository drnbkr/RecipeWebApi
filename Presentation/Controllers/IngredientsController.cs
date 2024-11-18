using System.Text.Json;
using Entities.Dtos.Ingredient;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;

namespace Presentation.Controllers
{
    [ApiExplorerSettings(GroupName = "v1")]
    [ServiceFilter(typeof(LogFilterAttribute))]
    [ApiController]
    [Route("api/ingredients")]
    public class IngredientsController : ControllerBase
    {
        private readonly IServiceManager _manager;
        public IngredientsController(IServiceManager manager)
        {
            _manager = manager;
        }

        //to do control cashing for this endpoint and add cache profile if needed
        [Authorize(Roles = "Editor, Admin, User")]
        [HttpGet(Name = "GetAllIngredientsAsync")]
        [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
        public async Task<IActionResult> GetAllIngredientsAsync([FromQuery] IngredientParameters ingredientParameters)
        {
            //to do upgrade search functionality

            var pagedResult = await _manager.IngredientService.GetAllIngredientsAsync(ingredientParameters, trackChanges: false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

            return Ok(pagedResult.ingredients);

        }

        [Authorize(Roles = "Admin, Editor")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost(Name = "CreateOneIngredientAsync")]
        public async Task<IActionResult> CreateOneIngredientAsync([FromBody] IngredientDtoForManipulation ingredientDtoForManipulation)
        {
            var ingredient = await _manager.IngredientService.CreateOneIngredientAsync(ingredientDtoForManipulation);

            return StatusCode(201, ingredient);
        }


        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("{id:int}", Name = "UpdateOneIngredientAsync")]
        public async Task<IActionResult> UpdateOneIngredientAsync([FromRoute(Name = "id")] int id, [FromBody] IngredientDtoForUpdate ingredientDtoForUpdate)
        {
            await _manager.IngredientService.UpdateOneIngredientAsync(id, ingredientDtoForUpdate, trackChanges: false);
            return NoContent();
        }
    }
}
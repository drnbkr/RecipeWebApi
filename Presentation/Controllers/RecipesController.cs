using System.Text.Json;
using Entities.Dtos.Recipe;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;

namespace Presentation.Controllers
{
    [ApiExplorerSettings(GroupName = "v1")]
    [ServiceFilter(typeof(LogFilterAttribute))]
    [ApiController]
    [Route("api/recipes")]
    [ResponseCache(CacheProfileName = "5mins")]
    public class RecipesController : ControllerBase
    {
        private readonly IServiceManager _manager;
        public RecipesController(IServiceManager manager)
        {
            _manager = manager;
        }

        [Authorize(Roles = "Editor, Admin, User")]
        [HttpHead]
        [HttpGet(Name = "GetAllRecipesAsync")]
        [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
        [ResponseCache(Duration = 60)]
        public async Task<IActionResult> GetAllRecipesAsync([FromQuery] RecipeParameters recipeParameters)
        {
            var pagedResult = await _manager.RecipeService.GetAllRecipesAsync(recipeParameters, trackChanges: false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

            return Ok(pagedResult.recipes);
        }

        [Authorize]
        [HttpGet("Categories")]
        public async Task<IActionResult> GetAllRecipesWithCategoriesAsync()
        {
            return Ok(await _manager.RecipeService.GetAllRecipesWithCategoriesAsync(false));
        }


        [Authorize(Roles = "Editor, Admin, User")]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneRecipeAsync([FromRoute(Name = "id")] int id)
        {
            var recipe = await _manager.RecipeService.GetOneRecipeByIdAsync(id, false);

            return Ok(recipe);
        }

        [Authorize(Roles = "Admin, Editor")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost(Name = "CreateOneRecipeAsync")]
        public async Task<IActionResult> CreateOneRecipeAsync([FromBody] RecipeDtoForInsertion recipeDtoForInsertion)
        {
            
            var recipe = await _manager.RecipeService.CreateOneRecipeAsync(recipeDtoForInsertion);

            return StatusCode(201, recipe);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneRecipeAsync([FromRoute(Name = "id")] int id, [FromBody] RecipeDtoForUpdate recipeDto)
        {
            await _manager.RecipeService.UpdateOneRecipeAsync(id, recipeDto, false);

            return NoContent(); //204
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneRecipeAsync([FromRoute(Name = "id")] int id)
        {
            await _manager.RecipeService.DeleteOneRecipeAsync(id, trackChanges: false);

            return NoContent();
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> PartiallyUpdateOneRecipeAsync([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<RecipeDtoForUpdate> recipePatch)
        {
            if (recipePatch is null)
                return BadRequest();


            var result = await _manager.RecipeService.GetOneRecipeForPatchAsync(id, false);


            recipePatch.ApplyTo(result.recipeDtoForUpdate, ModelState);

            TryValidateModel(result.recipeDtoForUpdate);
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            await _manager.RecipeService.SaveChangesForPatchAsync(result.recipeDtoForUpdate, result.recipe);

            return NoContent(); // 204
        }

        [HttpOptions]
        public IActionResult GetRecipesOptions()
        {
            Response.Headers.Add("Allow", "GET, PUT, POST, PATCH, DELETE, HEAD, OPTIONS");

            return Ok();
        }

    }
}
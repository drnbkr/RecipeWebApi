using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/recipes")]
     public class RecipesController : ControllerBase
    {
        private readonly IServiceManager _manager;
        public RecipesController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAllRecipes()
        {
            try
            {
                var recipes = _manager.RecipeService.GetAllRecipes(false);
                return Ok(recipes);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneRecipe([FromRoute(Name = "id")] int id)
        {
            try
            {
                var recipe = _manager.RecipeService.GetOneRecipeById(id, false);

                if (recipe is null)
                    return NotFound();

                return Ok(recipe);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }

        [HttpPost]
        public IActionResult CreateOneRecipe([FromBody] Recipe recipe)
        {
            try
            {
                if (recipe is null)
                    return BadRequest();

                _manager.RecipeService.CreateOneRecipe(recipe);

                return StatusCode(201, recipe);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneRecipe([FromRoute(Name = "id")] int id, [FromBody] Recipe recipe)
        {
            try
            {
                if (recipe is null)
                    return BadRequest(); //400

                _manager.RecipeService.UpdateOneRecipe(id, recipe, true);

                return NoContent(); //204
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneRecipe([FromRoute(Name = "id")] int id)
        {
            try
            {
                _manager.RecipeService.DeleteOneRecipe(id, false);

                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneRecipe([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<Recipe> recipePatch)
        {
            try
            {
                var entity = _manager.RecipeService.GetOneRecipeById(id, true);

                if (entity is null)
                    return NotFound();

                recipePatch.ApplyTo(entity);
                _manager.RecipeService.UpdateOneRecipe(id, entity, true);

                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
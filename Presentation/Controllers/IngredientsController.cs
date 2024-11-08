using System.Text.Json;
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
        [HttpHead]
        [HttpGet(Name = "GetAllIngredientsAsync")]
        [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
        public async Task<IActionResult> GetAllIngredientsAsync([FromQuery] IngredientParameters ingredientParameters)
        {
            //to do upgrade search functionality

            var pagedResult = await _manager.IngredientService.GetAllIngredientsAsync(ingredientParameters, trackChanges: false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

            return Ok(pagedResult.ingredients);

        }


        //to do create one ingredient endpoint
        //to do update one ingredient endpoint
    }
}
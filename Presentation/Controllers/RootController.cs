using Entities.LinkModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Presentation.ActionFilters;

namespace Presentation.Controllers
{

    [ApiController]
    [Route("api")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class RootController : ControllerBase
    {
        private readonly LinkGenerator _linkGenerator;

        public RootController(LinkGenerator linkGenerator)
        {
            _linkGenerator = linkGenerator;
        }

        [HttpGet(Name = "GetRoot")]
        [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
        public async Task<IActionResult> GetRoot([FromHeader(Name = "Accept")] string mediaType)
        {
            if (mediaType.Contains("application/vnd.recipeapp.apiroot"))
            {
                var list = new List<Link>()
                {
                    new Link(){
                        Href = _linkGenerator.GetUriByName(HttpContext, nameof(GetRoot), new{}),
                        Rel = "_self",
                        Method ="GET"
                    },
                     new Link(){
                        Href = _linkGenerator.GetUriByName(HttpContext, nameof(RecipesController.GetAllRecipesAsync), new{}),
                        Rel = "recipes",
                        Method ="GET"
                    },
                     new Link(){
                        Href = _linkGenerator.GetUriByName(HttpContext, nameof(RecipesController.CreateOneRecipeAsync), new{}),
                        Rel = "recipes",
                        Method ="POST"
                    }
                    //todo add all links
                };

                return Ok(list);
            }

            return NoContent(); //204
        }
    }
}
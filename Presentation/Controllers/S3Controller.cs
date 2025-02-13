using Amazon.S3;
using Amazon.S3.Transfer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;

namespace Presentation.Controllers
{
    [ApiExplorerSettings(GroupName = "v1")]
    [ServiceFilter(typeof(LogFilterAttribute))]
    [ApiController]
    [Route("api/s3")]
    public class S3Controller : ControllerBase
    {
        private readonly IServiceManager _manager;

        public S3Controller(IServiceManager manager)
        {
            _manager = manager;
        }

        [Authorize(Roles = "Admin, Editor, User")]
        [HttpPost(Name = "UploadMediaAsync")]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
        {

            var mediaUrl = await _manager.S3Service.UploadFileAsync(file);

            return StatusCode(201, mediaUrl);
        }
    }
}
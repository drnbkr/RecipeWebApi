using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _service;
        private readonly UserManager<User> _userManager;
        public AuthenticationController(IServiceManager service, UserManager<User> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        [HttpPost("check")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CheckEmail([FromBody] UserForRegistrationDto userForRegistrationDto)
        {
            var result = await _service.AuthenticationService.CheckEmail(userForRegistrationDto.Email);

            return Ok(result);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]  // This is the filter that will be executed for Dto validation(dto cannot be empty, and dto name must contains "Dto" for this filter to be executed) if dto empty return 400
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistrationDto)
        {
            var result = await _service.AuthenticationService.RegisterUser(userForRegistrationDto);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                }
                return BadRequest(ModelState);

            }

            // Kullanıcı için token oluşturma
            var tokenDto = await _service.AuthenticationService.CreateToken(populateExp: true);

            // Kullanıcı bilgilerini alma
            var user = await _userManager.FindByEmailAsync(userForRegistrationDto.Email);
            if (user == null)
            {
                return NotFound("User not found");
            }

            // Yanıt gövdesi
            var response = new
            {
                Token = tokenDto,
                User = new
                {
                    user.Id,
                    user.UserName,
                    user.Email
                }
            };

            // 201 Created yanıtını döndür
            return StatusCode(201, response);
        }

        [HttpPost("login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto userForAuthenticationDto)
        {
            if (!await _service.AuthenticationService.ValidateUser(userForAuthenticationDto))
            {
                return Unauthorized();
            }

            var tokenDto = await _service.AuthenticationService.CreateToken(populateExp: true);
            var user = await _userManager.FindByEmailAsync(userForAuthenticationDto.Email);

            // Yanıt gövdesi
            var response = new
            {
                Token = tokenDto,
                User = new
                {
                    userID = user.Id,
                    userName = user.UserName,
                    email = user.Email
                }
            };

            return Ok(response);
        }

        [HttpPost("refresh")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Refresh([FromBody] TokenDto tokenDto)
        {
            var tokenDtoToReturn = await _service.AuthenticationService.RefreshToken(tokenDto);

            return Ok(tokenDtoToReturn);
        }

    }
}
// Purpose: Dto for token response. This is the response that will be sent to the client after a successful login.
namespace Entities.Dtos
{
    public record TokenDto
    {
        public string AccessToken { get; init; } 
        public string RefreshToken { get; init; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record UserForAuthenticationDto
    {
        [Required(ErrorMessage = "User name is required")]
        public string? UserName { get; init; }

        [Required(ErrorMessage = "Password name is required")]
        public string? Password { get; set; }

        public string? Provider { get; init; } // Google, Apple, Facebook
        public string? ProviderKey { get; init; } // Unique identifier from the provider
    }
}
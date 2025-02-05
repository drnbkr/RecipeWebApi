using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record UserForAuthenticationDto
    {
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; init; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; init; }

        public string? Provider { get; init; } // Google, Apple, Facebook
        public string? ProviderKey { get; init; } // Unique identifier from the provider
    }
}
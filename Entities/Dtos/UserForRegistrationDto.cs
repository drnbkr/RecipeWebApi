namespace Entities.Dtos
{
    public record UserForRegistrationDto
    {
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public string? UserName { get; init; }
        public string? Email { get; init; }
        public string? Password { get; init; }
        public string? GoogleId { get; init; }
        public string? AppleId { get; init; }
        public string? FacebookId { get; init; }
        public string? PhoneNumber { get; init; }
        public ICollection<string>? Roles { get; init; }


    }
}
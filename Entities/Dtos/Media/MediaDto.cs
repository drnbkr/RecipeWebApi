namespace Entities.Dtos.Media
{
    public record MediaDto
    {
        public int Id { get; init; }
        public int? RecipeId { get; init; }
        public int? RecipeInstructionId { get; init; }
        public required string MediaPath { get; init; }
        public required string MediaType { get; init; }
        public bool IsCover { get; init; }
        public DateTime CreatedDate { get; init; }
        public string? CreatedBy { get; init; }
    }
}
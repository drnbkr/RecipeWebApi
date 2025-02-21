using Entities.Dtos.Media;

namespace Entities.Dtos.RecipeInstruction
{
    public record RecipeInstructionDto
    {
        public RecipeInstructionDto()
        {
            Medias = new List<MediaDto>();
        }
        public int Id { get; init; }
        public required int RecipeId { get; init; }
        public int Step { get; init; }
        public required string Description { get; init; }
        public ICollection<MediaDto> Medias { get; init; }
        public DateTime CreatedDate { get; init; }
        public string? CreatedBy { get; init; }

    }
}
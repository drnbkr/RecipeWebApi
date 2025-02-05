using Entities.Dtos.Media;

namespace Entities.Dtos.RecipeInstruction
{
    public record RecipeInstructionDto
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int Step { get; set; }
        public string Description { get; set; }
        public ICollection<MediaDto> Medias { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }

    }
}
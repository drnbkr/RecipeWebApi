
using Entities.Dtos.Media;
using Entities.Dtos.RecipeIngredient;
using Entities.Dtos.RecipeInstruction;

namespace Entities.Dtos.Recipe
{
    public record RecipeDto
    {
        public RecipeDto()
        {
            RecipeIngredients = new List<RecipeIngredientDto>();
            RecipeInstructions = new List<RecipeInstructionDto>();
            Medias = new List<MediaDto>();
        }
        public int Id { get; init; }
        public string? Title { get; init; }
        public string? Description { get; init; }
        public decimal Calorie { get; init; }
        public int CategoryId { get; init; }
        public DateTime CreatedDate { get; init; }
        public DateTime UpdatedDate { get; init; }
        public string? UserId { get; init; }
        public ICollection<RecipeIngredientDto> RecipeIngredients { get; init; }
        public ICollection<RecipeInstructionDto> RecipeInstructions { get; init; }
        public ICollection<MediaDto>? Medias { get; init; }
    }
}
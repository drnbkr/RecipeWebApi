
using Entities.Dtos.RecipeIngredient;
using Entities.Dtos.RecipeInstruction;

namespace Entities.Dtos.Recipe
{
    public record RecipeDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal Calorie { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string? UserId { get; set; }
        public ICollection<RecipeIngredientDto> RecipeIngredients { get; set; }
        public ICollection<RecipeInstructionDto> RecipeInstructions { get; set; }


    }
}

using Entities.Dtos.RecipeIngredient;

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
        public ICollection<RecipeIngredientDto> RecipeIngredients { get; set; }
    }
}
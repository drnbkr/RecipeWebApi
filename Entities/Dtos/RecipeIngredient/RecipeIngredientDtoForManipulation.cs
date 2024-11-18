using Entities.Dtos.Ingredient;

namespace Entities.Dtos.RecipeIngredient
{
    public record RecipeIngredientDtoForManipulation
    {
        public int IngredientId { get; init; }
        public int RecipeId { get; init; }
        public decimal? Quantity { get; init; }
        public string? Unit { get; init; }
        public DateTime CreatedDate { get; init; }
        public string? CreatedBy { get; init; }
    }
}
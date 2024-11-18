using Entities.Dtos.Ingredient;

namespace Entities.Dtos.RecipeIngredient
{
    public record RecipeIngredientDto
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public IngredientDto? Ingredient { get; set; }
        public decimal? Quantity { get; set; }
        public string? Unit { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
    }
}
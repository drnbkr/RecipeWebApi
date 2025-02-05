using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public required String Title { get; set; }
        public string? Description { get; set; }
        public decimal Calorie { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public required string UserId { get; set; }
        public User User { get; set; }
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
        public ICollection<RecipeInstruction> RecipeInstructions { get; set; }
        public ICollection<Media> Medias { get; set; }
    }
}
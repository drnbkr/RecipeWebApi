using Entities.Models;

namespace Entities.Dtos
{
    public record RecipeDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public decimal Calorie { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
namespace Entities.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public required String Title { get; set; }
        public decimal Calorie { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
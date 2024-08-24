namespace Entities.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public required String Title { get; set; }
        public decimal Calorie { get; set; }
    }
}
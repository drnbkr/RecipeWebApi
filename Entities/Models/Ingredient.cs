namespace Entities.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal? Calorie { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

//to do: add type of ingredient(fruit, vegetable, meat, etc) 
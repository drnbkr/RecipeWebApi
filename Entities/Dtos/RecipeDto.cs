namespace Entities.Dtos
{
    public record RecipeDto
    {
        public int Id { get; set; }
        public required String Title { get; set; }
        public decimal Calorie { get; set; }
    }
}
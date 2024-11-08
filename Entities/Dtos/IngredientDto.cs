namespace Entities.Dtos
{
    public record IngredientDto
    {
        public int Id { get; init; }
        public string? Name { get; set; }
        public decimal Calorie { get; set; }
    }
}
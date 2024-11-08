using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record IngredientDtoForManipulation
    {
        [Required(ErrorMessage = "Name is a required field.")]
        [MinLength(2, ErrorMessage = "Name must consist of at least 2 characters.")]
        [MaxLength(50, ErrorMessage = "Name must consist of at maximum 50 characters.")]
        public required string Name { get; init; }

        [Required(ErrorMessage = "Calorie is a required field.")]
        [Range(0, 20000)]
        public decimal Calorie { get; init; }
    }
}
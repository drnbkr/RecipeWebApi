using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public abstract record RecipeDtoForManipulation
    {
        [Required(ErrorMessage = "Title is a required field.")]
        [MinLength(2, ErrorMessage = "Title must consist of at least 2 characters.")]
        [MaxLength(50, ErrorMessage = "Title must consist of at maximum 50 characters.")]
        public required string Title { get; init; }

        [MaxLength(160, ErrorMessage = "Description must consist of at maximum 160 characters.")]
        public string? Description { get; init; }

        [Required(ErrorMessage = "Calorie is a required field.")]
        [Range(0, 20000)]
        public decimal Calorie { get; init; }

        [Required(ErrorMessage = "CategoryId is a required.")]
        public int CategoryId { get; init; }
    }
}
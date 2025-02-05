using System.ComponentModel.DataAnnotations;
using Entities.Dtos.RecipeIngredient;
using Entities.Dtos.RecipeInstruction;

namespace Entities.Dtos.Recipe
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

        [Required(ErrorMessage = "UserId is a required.")]
        public required string UserId { get; init; }

        public ICollection<RecipeIngredientDto> RecipeIngredients { get; init; }
        public ICollection<RecipeInstructionDto> RecipeInstructions { get; init; }
    }
}
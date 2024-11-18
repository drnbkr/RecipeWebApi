using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos.RecipeIngredient
{
    public record RecipeIngredientDtoForUpdate : RecipeIngredientDtoForManipulation
    {
        [Required]
        public int Id { get; init; }
    }
}
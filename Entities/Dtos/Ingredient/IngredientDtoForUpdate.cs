using System.ComponentModel.DataAnnotations;
using Entities.Dtos.Ingredient;

namespace Entities.Dtos.Ingredient
{
    public record IngredientDtoForUpdate : IngredientDtoForManipulation
    {
        [Required]
        public int Id { get; init; }
    }
}
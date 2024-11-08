using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record IngredientDtoForUpdate : IngredientDtoForManipulation
    {
        [Required]
        public int Id { get; set; }
    }
}
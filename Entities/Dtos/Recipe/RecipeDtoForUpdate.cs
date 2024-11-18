using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos.Recipe
{
    public record RecipeDtoForUpdate : RecipeDtoForManipulation
    {
        [Required]
        public int Id { get; init; }
    }
}
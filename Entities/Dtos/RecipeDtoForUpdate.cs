using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record RecipeDtoForUpdate : RecipeDtoForManipulation
    {
        [Required]
        public int Id { get; set; }
    }
}
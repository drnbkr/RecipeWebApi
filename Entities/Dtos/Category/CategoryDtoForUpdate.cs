using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos.Category
{
    public record CategoryDtoForUpdate : CategoryDtoForInsertion
    {
        [Required]
        public int Id { get; set; }
    }
}
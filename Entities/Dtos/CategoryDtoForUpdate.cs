using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record CategoryDtoForUpdate : CategoryDtoForInsertion
    {
        [Required]
        public int Id { get; set; }
    }
}
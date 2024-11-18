using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos.Category
{
    public record CategoryDtoForInsertion
    {
        [Required(ErrorMessage = "Name is a required field.")]
        [MinLength(2, ErrorMessage = "Name must consist of at least 2 characters.")]
        [MaxLength(50, ErrorMessage = "Name must consist of at maximum 50 characters.")]
        public required string Name { get; init; }
        public int ParentCategoryId { get; init; }
    }
}
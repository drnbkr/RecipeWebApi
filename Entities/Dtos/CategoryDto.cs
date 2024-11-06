namespace Entities.Dtos
{
    public record CategoryDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int ParentCategoryId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
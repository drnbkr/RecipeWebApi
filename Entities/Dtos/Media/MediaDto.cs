namespace Entities.Dtos.Media
{
    public record MediaDto
    {
        public int Id { get; set; }
        public int? RecipeId { get; set; }
        public int? RecipeInstructionId { get; set; }
        public string MediaPath { get; set; }
        public string MediaType { get; set; }
        public bool IsCover { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
    }
}
namespace Entities.Models
{
    public class Category
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int ParentCategoryId { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<Recipe> Recipes { get; set; }
    }
}
using System.Text.Json.Serialization;
using System.Xml.Serialization;
namespace Entities.Models
{
    public class Media
    {
        public int Id { get; set; }
        public int? RecipeId { get; set; }
        [JsonIgnore]
        [XmlIgnore]
        public Recipe? Recipe { get; set; }
        public int? RecipeInstructionId { get; set; }
        [JsonIgnore]
        [XmlIgnore]
        public RecipeInstruction? RecipeInstruction { get; set; }
        public string MediaPath { get; set; }
        public string MediaType { get; set; }
        public bool IsCover { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }

    }
}
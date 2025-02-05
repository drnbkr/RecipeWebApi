using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Entities.Models
{
    public class RecipeInstruction
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        [JsonIgnore]
        [XmlIgnore]
        public Recipe Recipe { get; set; }
        public int Step { get; set; }
        public string Description { get; set; }
        public ICollection<Media> Medias { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
    }
}
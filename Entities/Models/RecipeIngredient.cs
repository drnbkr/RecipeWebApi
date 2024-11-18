using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Entities.Models
{
    public class RecipeIngredient
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        [JsonIgnore]
        [XmlIgnore]
        public Recipe Recipe { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        public decimal? Quantity { get; set; }
        //gram, ml, glass, spoon etc
        public string? Unit { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
    }
}
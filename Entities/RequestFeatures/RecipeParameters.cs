namespace Entities.RequestFeatures
{
    public class RecipeParameters : RequestParameters
    {
        public uint MinCalorie { get; set; }
        public uint MaxCalorie { get; set; } = 20000;
        public bool ValidCalorieRange => MaxCalorie > MinCalorie;
        public string? SearchTerm { get; set; }

        public RecipeParameters()
        {
            OrderBy = "id";
        }
    }
}
using Entities.Models;

namespace Repositories.EFCore.Extensions
{
    public static class IngredientRepositoryExtensions
    {
        public static IQueryable<Ingredient> Search(this IQueryable<Ingredient> ingredients, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return ingredients;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            //todo  localization, and add search for description(show result after title result)
            return ingredients.Where(r => r.Name.ToLower().Contains(searchTerm));
        }
    }
}
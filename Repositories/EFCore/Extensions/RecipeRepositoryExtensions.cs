using System.Linq.Dynamic.Core;
using Entities.Models;

namespace Repositories.EFCore.Extensions
{
    public static class RecipeRepositoryExtensions
    {
        public static IQueryable<Recipe> FilterRecipes(this IQueryable<Recipe> recipes, uint minCalorie, uint maxCalorie) =>
            recipes.Where(recipe =>
             recipe.Calorie >= minCalorie &&
             recipe.Calorie <= maxCalorie);

        public static IQueryable<Recipe> Search(this IQueryable<Recipe> recipes, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return recipes;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            //todo  localization, and add search for description(show result after title result)
            return recipes.Where(r => r.Title.ToLower().Contains(searchTerm));
        }

        public static IQueryable<Recipe> Sort(this IQueryable<Recipe> recipes, string orderByQueryString)
        {

            // recipes?orderBy = title, calorie desc, id asc


            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return recipes.OrderBy(r => r.Id);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Recipe>(orderByQueryString);

            if (orderQuery is null)
                return recipes.OrderBy(r => r.Id);

            return recipes.OrderBy(orderQuery);

        }
    }
}
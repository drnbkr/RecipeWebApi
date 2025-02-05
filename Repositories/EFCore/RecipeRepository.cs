using System.Linq.Dynamic.Core;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore.Extensions;

namespace Repositories.EFCore
{
    public sealed class RecipeRepository : RepositoryBase<Recipe>, IRecipeRepository
    {
        public RecipeRepository(RepositoryContext context) : base(context)
        {

        }
        public void CreateOneRecipe(Recipe recipe)
        {
            Create(recipe);
            if (recipe.RecipeIngredients != null && recipe.RecipeIngredients.Count != 0)
            {
                foreach (var recipeIngredient in recipe.RecipeIngredients)
                {
                    _context.RecipeIngredients.Add(recipeIngredient);
                }
            }
        }

        public void DeleteOneRecipe(Recipe recipe) => Delete(recipe);

        public async Task<PagedList<Recipe>> GetAllRecipesAsync(RecipeParameters recipeParameters, bool trackChanges)
        {

            var recipes = await FindAll(trackChanges)
                .FilterRecipes(recipeParameters.MinCalorie, recipeParameters.MaxCalorie)
                .Search(recipeParameters.SearchTerm)
                .Sort(recipeParameters.OrderBy)
                .ToListAsync();

            return PagedList<Recipe>.ToPagedList(recipes, recipeParameters.PageNumber, recipeParameters.PageSize);
        }

        //to do : handle this method in GetAllRecipesAsync(send parameters isCategoryIncluded)
        public async Task<IEnumerable<Recipe>> GetAllRecipesWithCategoriesAsync(bool trackChanges)
        {
            return await _context.Recipes.Include(r => r.Category).OrderBy(b => b.Id).ToListAsync();

        }

        public async Task<Recipe> GetOneRecipeByIdAsync(int id, bool trackChanges) =>
           await FindByCondition(r => r.Id.Equals(id), trackChanges)
            .Include(ri => ri.RecipeIngredients)
                .ThenInclude(i => i.Ingredient)
            .Include(r => r.RecipeInstructions)
                .ThenInclude(ri => ri.Medias)
            .Include(r => r.Medias)
            .SingleOrDefaultAsync();

        public void UpdateOneRecipe(Recipe recipe) => Update(recipe);
    }
}
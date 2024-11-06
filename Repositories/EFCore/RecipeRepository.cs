using System.Linq.Dynamic.Core;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public sealed class RecipeRepository : RepositoryBase<Recipe>, IRecipeRepository
    {
        public RecipeRepository(RepositoryContext context) : base(context)
        {

        }
        public void CreateOneRecipe(Recipe recipe) => Create(recipe);

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

        public async Task<IEnumerable<Recipe>> GetAllRecipesWithCategoriesAsync(bool trackChanges)
        {
            return await _context.Recipes.Include(r => r.Category).OrderBy(b=>b.Id).ToListAsync();
        }

        public async Task<Recipe> GetOneRecipeByIdAsync(int id, bool trackChanges) =>
           await FindByCondition(r => r.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

        public void UpdateOneRecipe(Recipe recipe) => Update(recipe);
    }
}
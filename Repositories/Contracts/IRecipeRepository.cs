using Entities.Models;
using Entities.RequestFeatures;

namespace Repositories.Contracts
{
    public interface IRecipeRepository : IRepositoryBase<Recipe>
    {
        Task<PagedList<Recipe>> GetAllRecipesAsync(RecipeParameters recipeParameters, bool trackChanges);
        Task<Recipe> GetOneRecipeByIdAsync(int id, bool trackChanges);
        void CreateOneRecipe(Recipe recipe);
        void UpdateOneRecipe(Recipe recipe);
        void DeleteOneRecipe(Recipe recipe);
        Task<IEnumerable<Recipe>> GetAllRecipesWithCategoriesAsync(bool trackChanges);
    }
}
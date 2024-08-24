using Entities.Models;

namespace Repositories.Contracts
{
    public interface IRecipeRepository : IRepositoryBase<Recipe>
    {
        IQueryable<Recipe> GetAllRecipes(bool trackChanges);
        Recipe GetOneRecipeById(int id, bool trackChanges);
        void CreateOneRecipe(Recipe recipe);
        void UpdateOneRecipe(Recipe recipe);
        void DeleteOneRecipe(Recipe recipe);
    }
}
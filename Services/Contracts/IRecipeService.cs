using Entities.Models;

namespace Services.Contracts
{
    public interface IRecipeService
    {
        IEnumerable<Recipe> GetAllRecipes(bool trackChanges);

        Recipe GetOneRecipeById(int id, bool trackChanges);

        Recipe CreateOneRecipe(Recipe recipe);
        void UpdateOneRecipe(int id, Recipe recipe, bool trackChanges);
        void DeleteOneRecipe(int id, bool trackChanges);
    }
}
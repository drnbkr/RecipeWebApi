using System.Dynamic;
using Entities.Dtos;
using Entities.Dtos.Recipe;
using Entities.Models;
using Entities.RequestFeatures;

namespace Services.Contracts
{
    public interface IRecipeService
    {
        Task<(IEnumerable<ExpandoObject> recipes, MetaData metaData)> GetAllRecipesAsync(RecipeParameters recipeParameters, bool trackChanges);
        Task<IEnumerable<Recipe>> GetAllRecipesWithCategoriesAsync(bool trackChanges);
        Task<RecipeDto> GetOneRecipeByIdAsync(int id, bool trackChanges);
        Task<RecipeDto> CreateOneRecipeAsync(RecipeDtoForInsertion recipe);
        Task UpdateOneRecipeAsync(int id, RecipeDtoForUpdate recipeDto, bool trackChanges);
        Task DeleteOneRecipeAsync(int id, bool trackChanges);

        //tuple, more than 1 object for return type of function
        Task<(RecipeDtoForUpdate recipeDtoForUpdate, Recipe recipe)> GetOneRecipeForPatchAsync(int id, bool trackChanges);


        Task SaveChangesForPatchAsync(RecipeDtoForUpdate recipeDtoForUpdate, Recipe recipe);
    }
}
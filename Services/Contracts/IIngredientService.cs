using System.Dynamic;
using Entities.Dtos.Ingredient;
using Entities.RequestFeatures;

namespace Services.Contracts
{
    public interface IIngredientService
    {
        //to do if necessary create a new metadata class for ingredients
        Task<(IEnumerable<ExpandoObject> ingredients, MetaData metaData)> GetAllIngredientsAsync(IngredientParameters ingredientParameters, bool trackChanges);
        Task<IngredientDto> CreateOneIngredientAsync(IngredientDtoForManipulation ingredientDtoForManipulation);
        Task UpdateOneIngredientAsync(int id, IngredientDtoForUpdate ingredientDtoForUpdate, bool trackChanges);
        Task<IngredientDto> GetOneIngredientByIdAsync(int id, bool trackChanges);

        
    }
}
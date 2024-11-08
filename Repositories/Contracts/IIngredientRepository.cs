using Entities.Models;
using Entities.RequestFeatures;

namespace Repositories.Contracts
{
    public interface IIngredientRepository : IRepositoryBase<Ingredient>
    {
        void CreateOneIngredient(Ingredient ingredient);
        void UpdateOneIngredient(Ingredient ingredient);
        Task<PagedList<Ingredient>> GetAllIngredientsAsync(IngredientParameters ingredientParameters, bool trackChanges);
    }
}
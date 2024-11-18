using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore.Extensions;

namespace Repositories.EFCore
{
    public sealed class IngredientRepository : RepositoryBase<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateOneIngredient(Ingredient ingredient)
        {
            Create(ingredient);
        }

        public void UpdateOneIngredient(Ingredient ingredient)
        {
            Update(ingredient);
        }

        public async Task<PagedList<Ingredient>> GetAllIngredientsAsync(IngredientParameters ingredientParameters, bool trackChanges)
        {
            var ingredients = await FindAll(trackChanges)
                .Search(ingredientParameters.SearchTerm)
                .ToListAsync();

            return PagedList<Ingredient>.ToPagedList(ingredients, ingredientParameters.PageNumber, ingredientParameters.PageSize);
        }

        public async Task<Ingredient> GetIngredientByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(i => i.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

    }
}
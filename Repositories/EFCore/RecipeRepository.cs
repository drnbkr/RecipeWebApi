using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class RecipeRepository : RepositoryBase<Recipe>, IRecipeRepository
    {
        public RecipeRepository(RepositoryContext context) : base(context)
        {

        }
        public void CreateOneRecipe(Recipe recipe) => Create(recipe);

        public void DeleteOneRecipe(Recipe recipe) => Delete(recipe);

        public IQueryable<Recipe> GetAllRecipes(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(r => r.Id);

        public Recipe GetOneRecipeById(int id, bool trackChanges) =>
            FindByCondition(r => r.Id.Equals(id), trackChanges).SingleOrDefault();

        public void UpdateOneRecipe(Recipe recipe) => Update(recipe);
    }
}
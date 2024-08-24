using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class RecipeManager : IRecipeService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;

        public RecipeManager(IRepositoryManager manager, ILoggerService logger)
        {
            _manager = manager;
            _logger = logger;
        }

        public Recipe CreateOneRecipe(Recipe recipe)
        {
            _manager.Recipe.CreateOneRecipe(recipe);
            _manager.Save();
            return recipe;
        }

        public void DeleteOneRecipe(int id, bool trackChanges)
        {
            var entity = _manager.Recipe.GetOneRecipeById(id, false);
            if (entity is null)
            {
                string message = $"Recipe with id:{id} could not found.";
                _logger.LogInfo(message);
                throw new Exception(message);
            }

            _manager.Recipe.DeleteOneRecipe(entity);
            _manager.Save();
        }

        public IEnumerable<Recipe> GetAllRecipes(bool trackChanges)
        {
            return _manager.Recipe.GetAllRecipes(trackChanges);
        }

        public Recipe GetOneRecipeById(int id, bool trackChanges)
        {
            return _manager.Recipe.GetOneRecipeById(id, trackChanges);
        }

        public void UpdateOneRecipe(int id, Recipe recipe, bool trackChanges)
        {
            var entity = _manager.Recipe.GetOneRecipeById(id, trackChanges);
            if (entity is null)
            {
                string message = $"Recipe with id:{id} could not found.";
                _logger.LogInfo(message);
                throw new Exception(message);
            }

            if (recipe is null)
                throw new ArgumentNullException(nameof(recipe));

            entity.Title = recipe.Title;
            entity.Calorie = recipe.Calorie;

            _manager.Recipe.Update(entity);
            _manager.Save();
        }
    }
}
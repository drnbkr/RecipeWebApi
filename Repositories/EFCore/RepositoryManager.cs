using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly IRecipeRepository _recipeRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IIngredientRepository _ingredientRepository;

        public RepositoryManager(RepositoryContext context, IRecipeRepository recipeRepository, ICategoryRepository categoryRepository, IIngredientRepository ingredientRepository)
        {
            _context = context;
            _recipeRepository = recipeRepository;
            _categoryRepository = categoryRepository;
            _ingredientRepository = ingredientRepository;
        }

        public IRecipeRepository Recipe => _recipeRepository;

        public ICategoryRepository Category => _categoryRepository;

        public IIngredientRepository Ingredient => _ingredientRepository;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly IRecipeRepository _recipeRepository;
        private readonly ICategoryRepository _categoryRepository;

        public RepositoryManager(RepositoryContext context, IRecipeRepository recipeRepository, ICategoryRepository categoryRepository)
        {
            _context = context;
            _recipeRepository = recipeRepository;
            _categoryRepository = categoryRepository;
        }

        public IRecipeRepository Recipe => _recipeRepository;

        public ICategoryRepository Category => _categoryRepository;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
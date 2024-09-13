using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly Lazy<IRecipeRepository> _recipeRepository;

        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _recipeRepository = new Lazy<IRecipeRepository>(() => new RecipeRepository(_context));
        }

        public IRecipeRepository Recipe => _recipeRepository.Value;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
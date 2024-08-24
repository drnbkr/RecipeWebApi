using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ServisManager : IServiceManager
    {
        //test 2
        private readonly Lazy<IRecipeService> _recipeService;
        public ServisManager(IRepositoryManager repositoryManager, ILoggerService loggerService)
        {
            _recipeService = new Lazy<IRecipeService>(() => new RecipeManager(repositoryManager, loggerService));
        }
        public IRecipeService RecipeService => _recipeService.Value;
    }
}
using AutoMapper;
using Entities.Dtos;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ServisManager : IServiceManager
    {
        //test 2
        private readonly Lazy<IRecipeService> _recipeService;
        public ServisManager(IRepositoryManager repositoryManager, ILoggerService loggerService, IMapper mapper, IDataShaper<RecipeDto> shaper)
        {
            _recipeService = new Lazy<IRecipeService>(() => new RecipeManager(repositoryManager, loggerService, mapper, shaper));
        }
        public IRecipeService RecipeService => _recipeService.Value;
    }
}
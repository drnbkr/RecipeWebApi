using Services.Contracts;

namespace Services
{
    public class ServisManager : IServiceManager
    {
        //test 2
        private readonly IRecipeService _recipeService;
        private readonly ICategoryService _categoryService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IIngredientService _ingredientService;
        private readonly IS3Service _s3Service;

        public ServisManager(IRecipeService recipeService, ICategoryService categoryService, IAuthenticationService authenticationService, IIngredientService ingredientService, IS3Service s3Service)
        {
            _recipeService = recipeService;
            _categoryService = categoryService;
            _authenticationService = authenticationService;
            _ingredientService = ingredientService;
            _s3Service = s3Service;
        }

        // public ServisManager(IRepositoryManager repositoryManager,
        //     ILoggerService loggerService,
        //     IMapper mapper,
        //     IDataShaper<RecipeDto> shaper,
        //     IConfiguration configuration,
        //     UserManager<User> userManager)
        // {

        // }
        // _categoryService = new Lazy<ICategoryService>(() => new CategoryManager(repositoryManager,mapper));
        // _recipeService = new Lazy<IRecipeService>(() => new RecipeManager(repositoryManager, loggerService, mapper, shaper, _categoryService.Value));
        // _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationManager(loggerService, mapper, userManager, configuration));
        public IRecipeService RecipeService => _recipeService;

        public IAuthenticationService AuthenticationService => _authenticationService;

        public ICategoryService CategoryService => _categoryService;

        public IIngredientService IngredientService => _ingredientService;
        public IS3Service S3Service => _s3Service;
    }
}
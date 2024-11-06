using System.Dynamic;
using AutoMapper;
using Entities.Dtos;
using Entities.Exceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;
using static Entities.Exceptions.BadRequestException;

namespace Services
{
    public class RecipeManager : IRecipeService
    {
        private readonly ICategoryService _categoryService;
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        private readonly IDataShaper<RecipeDto> _shaper;


        public RecipeManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper, IDataShaper<RecipeDto> shaper, ICategoryService categoryService)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
            _shaper = shaper;
            _categoryService = categoryService;
        }

        public async Task<RecipeDto> CreateOneRecipeAsync(RecipeDtoForInsertion recipeDtoForInsertion)
        {
            var category = await _categoryService.GetOneCategoryByIdAsync(recipeDtoForInsertion.CategoryId, trackChanges: false);

            var entity = _mapper.Map<Recipe>(recipeDtoForInsertion);
            _manager.Recipe.CreateOneRecipe(entity);
            await _manager.SaveAsync();
            return _mapper.Map<RecipeDto>(entity);
        }

        public async Task DeleteOneRecipeAsync(int id, bool trackChanges)
        {
            var entity = await GetOneRecipeAndCheckExist(id, trackChanges);
            _manager.Recipe.DeleteOneRecipe(entity);
            await _manager.SaveAsync();
        }

        public async Task<(IEnumerable<ExpandoObject> recipes, MetaData metaData)> GetAllRecipesAsync(RecipeParameters recipeParameters, bool trackChanges)
        {
            if (!recipeParameters.ValidCalorieRange)
                throw new CalorieOutofRangeBadRequestException();

            var recipesWithMetaData = await _manager.Recipe.GetAllRecipesAsync(recipeParameters, trackChanges);

            var recipesDto = _mapper.Map<IEnumerable<RecipeDto>>(recipesWithMetaData);

            var shapedData = _shaper.ShapeData(recipesDto, recipeParameters.Fields);

            return (recipes: shapedData, metaData: recipesWithMetaData.MetaData);
        }

        public async Task<IEnumerable<Recipe>> GetAllRecipesWithCategoriesAsync(bool trackChanges)
        {
            return await _manager.Recipe.GetAllRecipesWithCategoriesAsync(trackChanges);
        }

        public async Task<RecipeDto> GetOneRecipeByIdAsync(int id, bool trackChanges)
        {
            var recipe = await GetOneRecipeAndCheckExist(id, trackChanges);
            return _mapper.Map<RecipeDto>(recipe);
        }

        public async Task<(RecipeDtoForUpdate recipeDtoForUpdate, Recipe recipe)> GetOneRecipeForPatchAsync(int id, bool trackChanges)
        {
            var recipe = await GetOneRecipeAndCheckExist(id, trackChanges);
            var recipeDtoForUpdate = _mapper.Map<RecipeDtoForUpdate>(recipe);
            return (recipeDtoForUpdate, recipe);
        }

        public async Task SaveChangesForPatchAsync(RecipeDtoForUpdate recipeDtoForUpdate, Recipe recipe)
        {
            _mapper.Map(recipeDtoForUpdate, recipe);
            _manager.Recipe.Update(recipe);
            await _manager.SaveAsync();
        }

        public async Task UpdateOneRecipeAsync(int id, RecipeDtoForUpdate recipeDto, bool trackChanges)
        {
            var entity = await GetOneRecipeAndCheckExist(id, trackChanges);
            entity = _mapper.Map<Recipe>(recipeDto);
            _manager.Recipe.Update(entity);
            await _manager.SaveAsync();
        }

        private async Task<Recipe> GetOneRecipeAndCheckExist(int id, bool trackChanges)
        {
            var entity = await _manager.Recipe.GetOneRecipeByIdAsync(id, trackChanges);
            if (entity is null)
                throw new RecipeNotFoundException(id);
            return entity;
        }
    }
}
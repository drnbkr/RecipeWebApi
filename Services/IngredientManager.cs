using System.Dynamic;
using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class IngredientManager : IIngredientService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        private readonly IDataShaper<IngredientDto> _shaper;

        public IngredientManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper, IDataShaper<IngredientDto> shaper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
            _shaper = shaper;
        }

        public async Task<IngredientDto> CreateOneIngredientAsync(IngredientDtoForManipulation ingredientDtoForManipulation)
        {
            var entity = _mapper.Map<Ingredient>(ingredientDtoForManipulation);
            //todo check entity name if ingredient already exists(maybe need to create GetIngredientByNameAsync)
            // if (ingredient already exist)
            // {
            //     throw new IngredientAlreadyExistsException(ingredientDtoForManipulation.Name);
            // }

            _manager.Ingredient.CreateOneIngredient(entity);
            await _manager.SaveAsync();
            return _mapper.Map<IngredientDto>(entity);
        }
        public async Task UpdateOneIngredientAsync(int id, IngredientDtoForUpdate ingredientDtoForUpdate, bool trackChanges)
        {
            //todo check if ingredient exists
            var entity = _mapper.Map<Ingredient>(ingredientDtoForUpdate);
            //todo check entity name if ingredient already exists(maybe need to create GetIngredientByNameAsync)
            // if (ingredient already exist)
            // {
            //     throw new IngredientAlreadyExistsException(ingredientDtoForManipulation.Name);
            // }
            _manager.Ingredient.UpdateOneIngredient(entity);
            await _manager.SaveAsync();
        }

        public async Task<(IEnumerable<ExpandoObject> ingredients, MetaData metaData)> GetAllIngredientsAsync(IngredientParameters ingredientParameters, bool trackChanges)
        {
            var ingredientsWithMetaData = await _manager.Ingredient.GetAllIngredientsAsync(ingredientParameters, trackChanges);
            var ingredientsDto = _mapper.Map<IEnumerable<IngredientDto>>(ingredientsWithMetaData);
            var shapedData = _shaper.ShapeData(ingredientsDto, ingredientParameters.Fields);
            return (ingredients: shapedData, metaData: ingredientsWithMetaData.MetaData);
        }

    }
}
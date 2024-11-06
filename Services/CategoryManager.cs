using AutoMapper;
using Entities.Dtos;
using Entities.Exceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public CategoryManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<CategoryDto> CreateOneCategoryAsync(CategoryDtoForInsertion categoryDtoForInsertion)
        {
            var category = _mapper.Map<Category>(categoryDtoForInsertion);
            _repositoryManager.Category.CreateOneCategory(category);
            await _repositoryManager.SaveAsync();
            return _mapper.Map<CategoryDto>(category);
        }

        public Task DeleteCategoryAsync(int id, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(bool trackChanges)
        {
            var categories = await _repositoryManager.Category.GetAllCategoriesAsync(trackChanges);
            var categoriesDto = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            return categoriesDto;
        }

        public async Task<CategoryDto> GetOneCategoryByIdAsync(int categoryId, bool trackChanges)
        {
            var category = await _repositoryManager.Category.GetOneCategoryByIdAsync(categoryId, trackChanges);
            if (category is null)
                throw new CategoryNotFoundException(categoryId);
            var categoryDto = _mapper.Map<CategoryDto>(category);
            return categoryDto;
        }

        public async Task UpdateOneCategoryAsync(int id, CategoryDtoForUpdate categoryDtoForUpdate, bool trackChanges)
        {
            var categoryEntity = await GetOneCategoryAndCheckExist(id, trackChanges);
            categoryEntity = _mapper.Map<Category>(categoryDtoForUpdate);
            _repositoryManager.Category.Update(categoryEntity);
            await _repositoryManager.SaveAsync();

        }

        private async Task<Category> GetOneCategoryAndCheckExist(int id, bool trackChanges)
        {
            var categoryEntity = await _repositoryManager.Category.GetOneCategoryByIdAsync(id, trackChanges);
            if (categoryEntity is null)
                throw new CategoryNotFoundException(id);
            return categoryEntity;
        }
    }
}
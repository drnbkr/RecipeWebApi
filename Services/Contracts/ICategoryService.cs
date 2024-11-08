using Entities.Dtos;

namespace Services.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(bool trackChanges);
        Task<CategoryDto> GetOneCategoryByIdAsync(int categoryId, bool trackChanges);
        Task<CategoryDto> CreateOneCategoryAsync(CategoryDtoForInsertion category);
        Task UpdateOneCategoryAsync(int id, CategoryDtoForUpdate category, bool trackChanges);
        Task DeleteCategoryAsync(int id, bool trackChanges);

    }
}
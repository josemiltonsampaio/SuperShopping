using SuperShopping.ProductAPI.DTO;

namespace SuperShopping.ProductAPI.Service;
public interface ICategoryService
{
    Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync(bool trackChanges);
    Task<CategoryDTO> GetCategoryAsync(int id, bool trackChanges);
    Task<CategoryDTO> CreateCategoryAsync(CategoryCreationDTO category);
    Task UpdateCategoryAsync(int categoryId, CategoryUpdateDTO categoryUpdateDTO, bool trackChanges);
    Task DeleteCategoryAsync(int categoryId, bool trackChanges);
}

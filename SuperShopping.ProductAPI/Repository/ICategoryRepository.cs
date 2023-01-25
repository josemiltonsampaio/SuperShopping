using SuperShopping.ProductAPI.Models;

namespace SuperShopping.ProductAPI.Repository;
public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges);
    Task<Category> GetCategoryAsync(int categoryId, bool trackChanges);
    Task<bool> CategoryInUseAsync(int categoryId);
    void CreateCategory(Category category);
    void DeleteCategory(Category category);
}

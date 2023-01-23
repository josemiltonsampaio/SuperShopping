using SuperShopping.ProductAPI.Models;

namespace SuperShopping.ProductAPI.Repository;
public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges);
    Task<Category> GetCategoryAsync(int id, bool trackChanges);
    void CreateCategory(Category category);
    void DeleteCategory(Category category);
}

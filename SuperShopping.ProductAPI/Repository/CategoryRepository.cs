using Microsoft.EntityFrameworkCore;
using SuperShopping.ProductAPI.Data;
using SuperShopping.ProductAPI.Models;
using SuperShopping.ProductAPI.Repository.Interfaces;

namespace SuperShopping.ProductAPI.Repository;
public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{

    public CategoryRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public async Task<bool> CategoryInUseAsync(int categoryId)
    {
        return await context.Product.AnyAsync(p => p.CategoryId == categoryId);
    }

    public void CreateCategory(Category category)
    {
        Add(category);
    }

    public void DeleteCategory(Category category)
    {
        Delete(category);
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges)
    {
        return await GetAll(trackChanges).ToListAsync();
    }

    public async Task<Category> GetCategoryAsync(int categoryId, bool trackChanges)
    {
        return await GettAllByQuery(c => c.Id == categoryId, trackChanges).SingleOrDefaultAsync();
    }
}

using Microsoft.EntityFrameworkCore;
using SuperShopping.CartAPI.Data;
using SuperShopping.CartAPI.Models;
using SuperShopping.CartAPI.Repository.Interfaces;

namespace SuperShopping.CartAPI.Repository;
public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }

    public void CreateProduct(Product product)
    {
        Add(product);
    }

    public void DeleteProduct(Product product)
    {
        Delete(product);
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges)
    {
        return await GetAll(trackChanges).ToListAsync();
    }

    public async Task<Product> GetProductAsync(int id, bool trackChanges)
    {
        return await GetAllByQuery(p => p.Id == id, trackChanges).FirstOrDefaultAsync();
    }

    public async Task<bool> ProductExistsAsync(int productId)
    {
        var product = await GetProductAsync(productId, false);
        return (product != null);
    }
}

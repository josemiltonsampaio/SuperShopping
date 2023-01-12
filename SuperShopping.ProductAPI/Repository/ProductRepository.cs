using Microsoft.EntityFrameworkCore;
using SuperShopping.ProductAPI.Data;
using SuperShopping.ProductAPI.Models;

namespace SuperShopping.ProductAPI.Repository;
public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }

    public void CreateProduct(Product product) => Add(product);

    public void DeleteProduct(Product product) => Delete(product);

    public async Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges)
    {
        return await GetAll(trackChanges).Include(p => p.Category).ToListAsync();
    }

    public async Task<Product> GetProductAsync(int id, bool trackChanges)
    {
        return await GettAllByQuery(p => p.Id == id, trackChanges).SingleOrDefaultAsync();
    }
}

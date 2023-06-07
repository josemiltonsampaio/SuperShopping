using Microsoft.EntityFrameworkCore;
using SuperShopping.ProductAPI.Data;
using SuperShopping.ProductAPI.Models;
using SuperShopping.ProductAPI.Repository.Interfaces;

namespace SuperShopping.ProductAPI.Repository;
public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }

    public void CreateProduct(Product product)
    {
        Add(product);
        context.Entry(product).Reference(p => p.Category).Load();
    }

    public void DeleteProduct(Product product) => Delete(product);

    public async Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges)
    {
        return await GetAll(trackChanges).Include(p => p.Category).ToListAsync();
        //return context.Product.FromSqlRaw<Product>("exec SP_SelectProducts").ToList();
    }

    public async Task<Product> GetProductAsync(int id, bool trackChanges)
    {
        return await GettAllByQuery(p => p.Id == id, trackChanges).Include(p => p.Category).SingleOrDefaultAsync();
    }
}

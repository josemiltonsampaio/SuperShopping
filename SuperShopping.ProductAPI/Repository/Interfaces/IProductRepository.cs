using SuperShopping.ProductAPI.Models;

namespace SuperShopping.ProductAPI.Repository.Interfaces;
public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges);
    Task<Product> GetProductAsync(int id, bool trackChanges);
    void CreateProduct(Product product);
    void DeleteProduct(Product product);
}

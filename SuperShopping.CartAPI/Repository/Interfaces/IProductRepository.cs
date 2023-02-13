using SuperShopping.CartAPI.Models;

namespace SuperShopping.CartAPI.Repository.Interfaces;
public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges);
    Task<Product> GetProductAsync(int id, bool trackChanges);
    Task<bool> ProductExistsAsync(int productId);
    void CreateProduct(Product product);
    void DeleteProduct(Product product);

}

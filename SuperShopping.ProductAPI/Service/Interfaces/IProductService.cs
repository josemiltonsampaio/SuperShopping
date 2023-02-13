using SuperShopping.ProductAPI.DTO;

namespace SuperShopping.ProductAPI.Service.Interfaces;
public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetAllProductsAsync(bool trackChanges);
    Task<ProductDTO> GetProductAsync(int productId, bool trackChanges);
    Task<ProductDTO> CreateProductAsync(ProductCreationDTO product);
    Task DeleteProductAsync(int productId);
    Task UpdateProductAsync(int productId, ProductUpdateDTO productForUpdate);
}

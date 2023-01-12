using SuperShopping.ProductAPI.DTO;

namespace SuperShopping.ProductAPI.Service;
public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetAllProductsAsync(bool trackChanges);
    Task<ProductDTO> GetProductAsync(int productId, bool trackChanges);
    Task<ProductDTO> CreateProductAsync(ProductCreationDTO product);
    Task DeleteProductAsync(int ProductId, bool trackChanges);
    Task UpdateProductAsync(int ProductId, ProductUpdateDTO productForUpdate, bool trackChanges);
}

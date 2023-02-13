using SuperShopping.CartAPI.DTO;

namespace SuperShopping.CartAPI.Services.Interfaces;
public interface IProductService
{
    Task<ProductDTO> CreateProductAsync(ProductCreationDTO product);
}

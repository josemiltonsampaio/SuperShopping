using AutoMapper;
using SuperShopping.CartAPI.DTO;
using SuperShopping.CartAPI.Models;
using SuperShopping.CartAPI.Repository.Interfaces;
using SuperShopping.CartAPI.Services.Interfaces;

namespace SuperShopping.CartAPI.Services;
public class ProductService : IProductService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public ProductService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }
    public async Task<ProductDTO> CreateProductAsync(ProductCreationDTO product)
    {
        var existingProduct = await _repositoryManager.ProductRepository.GetProductAsync(product.Id, false);
        if (existingProduct != null)
        {
            return _mapper.Map<ProductDTO>(existingProduct);
        }

        var newProduct = _mapper.Map<Product>(product);
        _repositoryManager.ProductRepository.CreateProduct(newProduct);
        await _repositoryManager.SaveAsync();
        return _mapper.Map<ProductDTO>(newProduct);
    }
}

using AutoMapper;
using SuperShopping.ProductAPI.DTO;
using SuperShopping.ProductAPI.Infrastructure.Exceptions;
using SuperShopping.ProductAPI.Models;
using SuperShopping.ProductAPI.Repository;

namespace SuperShopping.ProductAPI.Service;
public class ProductService : IProductService
{
    private readonly IRepositoryManager repository;
    private readonly IMapper mapper;

    public ProductService(IRepositoryManager repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }
    public async Task<ProductDTO> CreateProductAsync(ProductCreationDTO product)
    {
        var category = await repository.Category.GetCategoryAsync(product.CategoryId, false);
        if (category is null)
        {
            throw new CategoryNotFoundException(product.CategoryId);
        }

        var productToInsert = mapper.Map<Product>(product);
        repository.Product.CreateProduct(productToInsert);
        await repository.SaveAsync();


        return mapper.Map<ProductDTO>(productToInsert);
    }

    public async Task DeleteProductAsync(int productId)
    {
        var product = await repository.Product.GetProductAsync(productId, true);
        repository.Product.DeleteProduct(product);
        await repository.SaveAsync();
    }

    public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync(bool trackChanges)
    {
        return mapper.Map<List<ProductDTO>>(await repository.Product.GetAllProductsAsync(trackChanges));


    }

    public async Task<ProductDTO> GetProductAsync(int productId, bool trackChanges)
    {
        var product = await repository.Product.GetProductAsync(productId, trackChanges);
        return mapper.Map<ProductDTO>(product);
    }

    public async Task UpdateProductAsync(int productId, ProductUpdateDTO productForUpdate)
    {
        var productEntity = await repository.Product.GetProductAsync(productId, true);

        var category = await repository.Category.GetCategoryAsync(productForUpdate.CategoryId, false);
        if (category is null)
        {
            throw new CategoryNotFoundException(productForUpdate.CategoryId);
        }

        mapper.Map(productForUpdate, productEntity);
        await repository.SaveAsync();
    }
}

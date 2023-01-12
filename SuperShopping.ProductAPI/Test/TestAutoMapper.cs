using BenchmarkDotNet.Attributes;
using SuperShopping.ProductAPI.DTO;
using SuperShopping.ProductAPI.Models;

namespace SuperShopping.ProductAPI.Test;
[InProcess]
public class TestAutoMapper
{
    private Product[] _products;
    int NumberOfItems = 100000;

    [GlobalSetup]
    public void Init()
    {
        _products = Enumerable.Range(1, NumberOfItems)
            .Select(i => new Product
            {
                Id = i,
                Name = $"Product name {i}",
                Description = $"Product description {i}",
                Price = 12.34m,
                CategoryId = 1,
                ImageUrl = ""
            }).ToArray();
    }


    [Benchmark]
    public ProductDTO[] With_Direct_Assignment()
    {
        ProductDTO[] products = new ProductDTO[NumberOfItems];
        int index = 0;

        foreach (var product in _products)
        {
            products[index] = ProductDTO.FromProduct(product);
            index++;
        }
        return products;
    }

}

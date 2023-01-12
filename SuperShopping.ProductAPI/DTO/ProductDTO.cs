using SuperShopping.ProductAPI.Models;

namespace SuperShopping.ProductAPI.DTO;
public class ProductDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public CategoryDTO Category { get; set; }

    public static ProductDTO FromProduct(Product product)
    {
        return new ProductDTO
        {
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            ImageUrl = product.ImageUrl,
            Category = new CategoryDTO
            {
                Name = product.Category.Name
            }
        };
    }
}

public class ProductCreationDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public int CategoryId { get; set; }
}

public class ProductUpdateDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public int CategoryId { get; set; }
}

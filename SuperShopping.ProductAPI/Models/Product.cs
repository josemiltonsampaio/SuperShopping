using System.ComponentModel.DataAnnotations;

namespace SuperShopping.ProductAPI.Models;
public class Product
{
    public int Id { get; set; }
    [MaxLength(150)]
    public string Name { get; set; }
    [MaxLength(300)]
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }
}

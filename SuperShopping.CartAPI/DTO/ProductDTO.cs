using System.ComponentModel.DataAnnotations;

namespace SuperShopping.CartAPI.DTO;
public class ProductDTO
{
    [Required]
    public int Id { get; set; }
    [MaxLength(150)]
    [Required]
    public string Name { get; set; }
    [MaxLength(300)]
    [Required]
    public string Description { get; set; }
    [Required]
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
}

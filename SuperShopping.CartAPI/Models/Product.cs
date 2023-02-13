using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperShopping.CartAPI.Models;
public class Product
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
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

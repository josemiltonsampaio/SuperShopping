namespace SuperShopping.CartAPI.DTO;
public class CartCreationDTO
{
    public int UserId { get; set; }
    public List<CartItemCreationDTO> Items { get; set; } = new List<CartItemCreationDTO>();
}


public class CartItemCreationDTO
{
    public ProductCreationDTO Product { get; set; } = new ProductCreationDTO();
    public int Quantity { get; set; }
}

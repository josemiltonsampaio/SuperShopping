namespace SuperShopping.CartAPI.DTO;
public class CartDTO
{
    public int UserId { get; set; }
    public List<CartItemDTO> Items { get; set; } = new List<CartItemDTO>();
}

public class CartItemDTO
{
    public int Id { get; set; }
    public ProductDTO Product { get; set; } = new ProductDTO();
    public int Quantity { get; set; }
}

namespace SuperShopping.CartAPI.Models;
public class CartHeader
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public virtual List<CartItem> Items { get; set; } = new List<CartItem>();
}

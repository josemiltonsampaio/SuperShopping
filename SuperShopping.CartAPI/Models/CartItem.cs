namespace SuperShopping.CartAPI.Models;
public class CartItem
{
    public int Id { get; set; }
    public int CartHeaderId { get; set; }
    public virtual CartHeader CartHeader { get; set; }
    public int ProductId { get; set; }
    public virtual Product Product { get; set; } = new Product();
    public int Quantity { get; set; }
}

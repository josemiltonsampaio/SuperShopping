namespace SuperShopping.OrderAPI.Models;
public class OrderItem
{
    public int Id { get; set; }
    public int OrderHeaderId { get; set; }
    public virtual OrderHeader OrderHeader { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}

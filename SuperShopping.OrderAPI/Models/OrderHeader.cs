namespace SuperShopping.OrderAPI.Models;
public class OrderHeader
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string CardNumber { get; set; }
    public string CVV { get; set; }
    public string ExpirationDate { get; set; }
    public DateTime PurchaseTime { get; set; }
    public DateTime OrderTime { get; set; }
    public bool PaymentStatus { get; set; }
    public virtual List<OrderItem> Items { get; set; } = new List<OrderItem>();
}

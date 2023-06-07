using SuperShopping.OrderAPI.Models;

namespace SuperShopping.OrderAPI.DTO;

public class CheckoutDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateTime { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string CardNumber { get; set; }
    public string CVV { get; set; }
    public string ExpirationDate { get; set; }
    public OrderHeader Cart { get; set; }


}

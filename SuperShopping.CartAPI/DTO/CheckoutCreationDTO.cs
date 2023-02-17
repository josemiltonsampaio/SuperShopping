namespace SuperShopping.CartAPI.DTO;
public class CheckoutCreationDTO
{
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string CardNumber { get; set; }
    public string CVV { get; set; }
    public string ExpirationDate { get; set; }
}

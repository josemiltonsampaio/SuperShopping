﻿using SuperShopping.MessageBus;

namespace SuperShopping.CartAPI.DTO;
public class CheckoutDTO : BaseMessage
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
    public CartDTO Cart { get; set; }
}

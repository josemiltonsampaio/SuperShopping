using Microsoft.AspNetCore.Identity;

namespace SuperShopping.AuthAPI.Models;
public class User : IdentityUser<int>
{
    public DateTime DateOfBirth { get; set; }
}

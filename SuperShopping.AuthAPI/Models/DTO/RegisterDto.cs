using System.ComponentModel.DataAnnotations;

namespace SuperShopping.AuthAPI.Models.DTO;
public class RegisterDto
{
    [Required]
    public string UserName { get; set; }
    [Required]
    public string ConfirmationToken { get; set; }
}

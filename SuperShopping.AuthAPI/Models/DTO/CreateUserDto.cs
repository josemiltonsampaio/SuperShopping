using System.ComponentModel.DataAnnotations;

namespace SuperShopping.AuthAPI.Models.DTO;
public class CreateUserDto
{
    [Required]
    public string Username { get; set; }
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Required]
    public string RePassword { get; set; }

}

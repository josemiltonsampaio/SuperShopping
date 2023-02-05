using Microsoft.IdentityModel.Tokens;
using SuperShopping.AuthAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SuperShopping.AuthAPI.Services;
public class TokenService
{
    public string CreateToken(User user)
    {
        Claim[] claims = new Claim[]
        {
            new Claim("username",user.UserName),
            new Claim("id",user.Id.ToString()),
            new Claim(ClaimTypes.DateOfBirth,user.DateOfBirth.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysupersecretkey#123"));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            signingCredentials: credentials,
            expires: DateTime.UtcNow.AddHours(1)
            );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
        return (tokenString);
    }
}

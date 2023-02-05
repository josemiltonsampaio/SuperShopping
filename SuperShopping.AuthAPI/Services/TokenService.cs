using Microsoft.IdentityModel.Tokens;
using SuperShopping.AuthAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SuperShopping.AuthAPI.Services;
public class TokenService
{
    public string CreateToken(User user, List<string> roles)
    {
        var claims = new List<Claim>
        {
            new Claim("username",user.UserName),
            new Claim("id",user.Id.ToString()),
            new Claim(ClaimTypes.DateOfBirth,user.DateOfBirth.ToString())
        };

        roles.ForEach((role) => claims.Add(new Claim(ClaimTypes.Role, role)));

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

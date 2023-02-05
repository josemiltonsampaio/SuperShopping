using Microsoft.AspNetCore.Identity;
using SuperShopping.AuthAPI.Models;
using SuperShopping.AuthAPI.Models.DTO;

namespace SuperShopping.AuthAPI.Services;
public class LoginService
{
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;
    private readonly TokenService _tokenService;

    public LoginService(SignInManager<User> signInManager, UserManager<User> userManager, TokenService tokenService)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _tokenService = tokenService;
    }

    public async Task<string> LoginUser(LoginUserDto loginUserDto)
    {

        var result = await _signInManager.PasswordSignInAsync(loginUserDto.UserName.ToUpper(), loginUserDto.Password, false, false);
        if (!result.Succeeded)
        {
            throw new BadHttpRequestException("Error trying to log in.");
        }

        var user = _signInManager.UserManager.Users.FirstOrDefault(u => u.NormalizedUserName == loginUserDto.UserName.ToUpper());
        var roles = await _signInManager.UserManager.GetRolesAsync(user);

        var token = _tokenService.CreateToken(user, roles.ToList());

        return token;
    }

    public async Task LogoutUser()
    {
        await _signInManager.SignOutAsync();
    }
}

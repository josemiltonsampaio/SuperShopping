using Microsoft.AspNetCore.Mvc;
using SuperShopping.AuthAPI.Models.DTO;
using SuperShopping.AuthAPI.Services;

namespace SuperShopping.AuthAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase
{
    private readonly LoginService _loginService;

    public LoginController(LoginService loginService)
    {
        _loginService = loginService;
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginUserDto loginUserDto)
    {
        return Ok(await _loginService.LoginUser(loginUserDto));
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await _loginService.LogoutUser();
        return Ok();
    }

}

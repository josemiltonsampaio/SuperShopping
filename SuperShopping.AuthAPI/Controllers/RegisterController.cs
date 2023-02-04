using Microsoft.AspNetCore.Mvc;
using SuperShopping.AuthAPI.Models.DTO;
using SuperShopping.AuthAPI.Services;

namespace SuperShopping.AuthAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class RegisterController : ControllerBase
{
    private readonly RegisterService _registerService;

    public RegisterController(RegisterService registerService)
    {
        _registerService = registerService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserDto createUser)
    {
        return Ok(await _registerService.RegisterUser(createUser));
    }

    [HttpPost("{id}/{token}")]
    public async Task<IActionResult> ConfirmUser(int id, string token)
    {
        await _registerService.ActivateUser(id, token);
        return Ok();
    }


}

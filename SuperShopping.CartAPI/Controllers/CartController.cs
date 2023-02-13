using Microsoft.AspNetCore.Mvc;
using SuperShopping.CartAPI.DTO;
using SuperShopping.CartAPI.Services.Interfaces;

namespace SuperShopping.CartAPI.Controllers;
[Controller()]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public CartController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }
    [HttpPost]
    public async Task<IActionResult> CreateCart([FromBody] CartCreationDTO cart)
    {
        return Ok(await _serviceManager.CartService.SaveOrUpdateCartAsync(cart));
    }

}

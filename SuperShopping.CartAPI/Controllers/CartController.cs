using Microsoft.AspNetCore.Mvc;
using SuperShopping.CartAPI.DTO;
using SuperShopping.CartAPI.Services.Interfaces;

namespace SuperShopping.CartAPI.Controllers;
[ApiController()]
[Route("api/[controller]/user/{userId}")]
public class CartController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public CartController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }
    [HttpPost]
    public async Task<IActionResult> CreateCart(CartCreationDTO cart)
    {
        return Ok(await _serviceManager.CartService.SaveOrUpdateCartAsync(cart));
    }

    [HttpGet]
    public async Task<IActionResult> FindCartById(int userId)
    {
        return Ok(await _serviceManager.CartService.GetCartByUserIdAsync(userId, false));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCart(CartCreationDTO cart)
    {
        return Ok(await _serviceManager.CartService.SaveOrUpdateCartAsync(cart));
    }

    [HttpDelete("/api/[controller]/item/{idItem}")]
    public async Task<IActionResult> RemoveItemFromCart(int idItem)
    {
        await _serviceManager.CartService.RemoveItemFromCartAsync(idItem);
        return NoContent();
    }

}

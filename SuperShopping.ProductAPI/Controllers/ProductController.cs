using Microsoft.AspNetCore.Mvc;
using SuperShopping.ProductAPI.Service;

namespace SuperShopping.ProductAPI.Controllers;
[Route("api/product")]
public class ProductController : ControllerBase
{
    private readonly IServiceManager serviceManager;

    public ProductController(IServiceManager serviceManager)
    {
        this.serviceManager = serviceManager;
    }

    public async Task<IActionResult> GetAllProducts()
    {
        return Ok(await serviceManager.Product.GetAllProductsAsync(false));
    }
}

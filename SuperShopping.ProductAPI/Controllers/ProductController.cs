using Microsoft.AspNetCore.Mvc;
using SuperShopping.ProductAPI.DTO;
using SuperShopping.ProductAPI.Service;

namespace SuperShopping.ProductAPI.Controllers;
[Controller]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IServiceManager serviceManager;

    public ProductController(IServiceManager serviceManager)
    {
        this.serviceManager = serviceManager;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        return Ok(await serviceManager.Product.GetAllProductsAsync(false));
    }

    [HttpGet("{id:int}", Name = nameof(GetProduct))]
    public async Task<IActionResult> GetProduct(int id)
    {
        return Ok(await serviceManager.Product.GetProductAsync(id, false));
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductCreationDTO product)
    {
        if (!ModelState.IsValid)
        {
            return UnprocessableEntity(ModelState);
        }
        var createdProduct = await serviceManager.Product.CreateProductAsync(product);
        return CreatedAtAction(nameof(GetProduct), new { createdProduct.Id }, createdProduct);
    }
}

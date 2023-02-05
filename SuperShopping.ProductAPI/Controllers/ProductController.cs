using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperShopping.ProductAPI.DTO;
using SuperShopping.ProductAPI.Service;

namespace SuperShopping.ProductAPI.Controllers;
[Controller]
[Route("api/[controller]")]
[Authorize]
public class ProductController : ControllerBase
{
    private readonly IServiceManager serviceManager;

    public ProductController(IServiceManager serviceManager)
    {
        this.serviceManager = serviceManager;
    }
    [HttpGet]
    [Authorize(Roles = "user")]
    public async Task<IActionResult> GetAllProducts()
    {
        return Ok(await serviceManager.Product.GetAllProductsAsync(false));
    }

    [HttpGet("{productId:int}", Name = nameof(GetProduct))]
    [Authorize(Roles = "user")]
    public async Task<IActionResult> GetProduct(int productId)
    {
        return Ok(await serviceManager.Product.GetProductAsync(productId, false));
    }

    [HttpPost]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> CreateProduct([FromBody] ProductCreationDTO product)
    {
        if (!ModelState.IsValid)
        {
            return UnprocessableEntity(ModelState);
        }
        var createdProduct = await serviceManager.Product.CreateProductAsync(product);
        return CreatedAtAction(nameof(GetProduct), new { createdProduct.Id }, createdProduct);
    }

    [HttpPut("{productId:int}")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> UpdateProduct(int productId, [FromBody] ProductUpdateDTO productUpdateDTO)
    {
        if (!ModelState.IsValid)
        {
            return UnprocessableEntity(ModelState);
        }

        await serviceManager.Product.UpdateProductAsync(productId, productUpdateDTO);

        return NoContent();
    }

    [HttpDelete("{productId:int}")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> DeleteProduct(int productId)
    {
        await serviceManager.Product.DeleteProductAsync(productId);
        return NoContent();
    }
}

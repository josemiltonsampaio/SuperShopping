using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperShopping.ProductAPI.DTO;
using SuperShopping.ProductAPI.Service;

namespace SuperShopping.ProductAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CategoryController : ControllerBase
{
    private readonly IServiceManager serviceManager;

    public CategoryController(IServiceManager serviceManager)
    {
        this.serviceManager = serviceManager;
    }

    [HttpGet]
    [Authorize(Roles = ("user,admin"))]
    public async Task<IActionResult> GetCategories()
    {
        return Ok(await serviceManager.Category.GetAllCategoriesAsync(false));
    }

    [Authorize(Roles = ("user,admin"))]
    [HttpGet("{id:int}", Name = nameof(GetCategories))]
    public async Task<IActionResult> GetCategory(int id)
    {
        return Ok(await serviceManager.Category.GetCategoryAsync(id, false));
    }

    [HttpPut("{categoryId}")]
    [Authorize(Roles = ("admin"))]
    public async Task<IActionResult> UpdateCategory(int categoryId, [FromBody] CategoryUpdateDTO categoryUpdateDTO)
    {
        if (categoryUpdateDTO is null)
            return BadRequest("CategoryUpdateDTO object is null");

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        await serviceManager.Category.UpdateCategoryAsync(categoryId, categoryUpdateDTO);

        return NoContent();
    }

    [HttpDelete("{categoryId}")]
    [Authorize(Roles = ("admin"))]
    public async Task<IActionResult> DeleteCategory(int categoryId)
    {
        await serviceManager.Category.DeleteCategoryAsync(categoryId);
        return NoContent();
    }

    [HttpPost]
    [Authorize(Roles = ("admin"))]
    public async Task<IActionResult> CreateCategory(CategoryCreationDTO categoryCreationDTO)
    {
        var categoryCreated = await serviceManager.Category.CreateCategoryAsync(categoryCreationDTO);
        return CreatedAtAction(nameof(GetCategory), new { id = categoryCreated.Id }, categoryCreated);

    }


}

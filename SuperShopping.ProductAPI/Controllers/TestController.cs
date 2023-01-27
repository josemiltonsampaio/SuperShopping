using Microsoft.AspNetCore.Mvc;

namespace SuperShopping.ProductAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    [HttpPost]
    public IActionResult Echo([FromBody] string message) => Ok(message);

    [HttpGet] public IActionResult Time() => Ok(DateTime.Now);
}

using BenchmarkDotNet.Running;
using Microsoft.AspNetCore.Mvc;
using SuperShopping.ProductAPI.Test;

namespace SuperShopping.ProductAPI.Controllers;
[Route("api/test")]

public class TestController : ControllerBase
{
    public IActionResult Test()
    {
        var teste = BenchmarkRunner.Run<TestAutoMapper>();
        return Ok("TesteJM");
    }

}

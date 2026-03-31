using Microsoft.AspNetCore.Mvc;
using ECommerceAPI.Helpers;  // static Logger

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    [HttpGet("{id}")]
    public IActionResult GetProduct(int id)
    {
        Logger.LogInfo($"Fetching product {id}");

        var product = id == 1 ? new { Id = 1, Name = "Laptop" } : null;

        if (product == null)
        {
            Logger.LogWarn($"Product {id} not found");
            return NotFound();
        }

        return Ok(product);
    }
}
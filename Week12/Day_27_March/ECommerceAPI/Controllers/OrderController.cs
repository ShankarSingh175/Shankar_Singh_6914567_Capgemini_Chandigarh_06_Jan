using Microsoft.AspNetCore.Mvc;
using ECommerceAPI.Helpers; // static Logger

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    [HttpPost("create")]
    public IActionResult CreateOrder([FromBody] OrderRequest request)
    {
        Logger.LogInfo($"Order started for user {request.UserId}");

        try
        {
            if (request.ProductId <= 0)
                throw new ArgumentException("Invalid product ID");

            Logger.LogInfo("Order created successfully");
            return Ok("Order placed");
        }
        catch (Exception ex)
        {
            Logger.LogError("Order failed", ex);
            return StatusCode(500, "Internal server error");
        }
    }
}

public class OrderRequest
{
    public int UserId { get; set; }
    public int ProductId { get; set; }
}
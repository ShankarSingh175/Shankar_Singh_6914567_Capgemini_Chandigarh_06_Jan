using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using log4net;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private static readonly ILog _logger = LogManager.GetLogger(typeof(OrdersController));

    [Authorize]
    [HttpGet]
    public IActionResult GetOrders()
    {
        _logger.Info("GET /api/orders called");

        return Ok(new[]
        {
            new { Id = 1, Product = "Laptop" },
            new { Id = 2, Product = "Mobile" }
        });
    }
}
using Microsoft.AspNetCore.Mvc;
using ECommerceAPI.Helpers;  // static Logger

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    [HttpPost("pay")]
    public IActionResult Pay([FromBody] PaymentRequest request)
    {
        Logger.LogInfo($"Payment request for order {request.OrderId}");

        var rnd = new Random();
        var delay = rnd.Next(1, 10); // simulate delay

        if (delay > 5)
            Logger.LogWarn($"Payment delay: {delay} sec");

        try
        {
            if (rnd.NextDouble() < 0.3) // simulate 30% chance of failure
                throw new Exception("Payment timeout");

            return Ok("Payment successful");
        }
        catch (Exception ex)
        {
            Logger.LogError($"Payment failed for order {request.OrderId}", ex);
            return StatusCode(500, "Payment failed");
        }
    }
}

public class PaymentRequest
{
    public int OrderId { get; set; }
    public decimal Amount { get; set; }
}
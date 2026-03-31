using Microsoft.AspNetCore.Mvc;
using ECommerceAPI.Helpers;   // ✅ add this
namespace ECommerceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]  // This makes the route: /api/user
    public class UserController : ControllerBase
    {
        [HttpPost("login")]      // Full route: /api/user/login
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (request.Email == "test@gmail.com" && request.Password == "1234")
            {
                Helpers.Logger.LogInfo($"Login attempt: {request.Email}");
                return Ok("Login successful");
            }
            else
            {
                Helpers.Logger.LogWarn($"Invalid password for {request.Email}");
                return Unauthorized("Invalid credentials");
            }
        }
    }

    public class LoginRequest
{
    public string Email { get; set; } = string.Empty;      // initialize to avoid CS8618
    public string Password { get; set; } = string.Empty;   // initialize to avoid CS8618
}
}
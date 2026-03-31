using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EventBooking.API.Models;
using EventBooking.API.Data;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _config;

    public AuthController(AppDbContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }

    // ==============================
    // REGISTER
    // ==============================
    [HttpPost("register")]
    public IActionResult Register([FromBody] UserDto dto)
    {
        if (dto == null || string.IsNullOrWhiteSpace(dto.Username) || string.IsNullOrWhiteSpace(dto.Password))
            return BadRequest("Invalid data");

        if (_context.Users.Any(u => u.Username == dto.Username))
            return BadRequest("Username already exists");

        var user = new AppUser
        {
            Username = dto.Username,
            Password = dto.Password
        };

        _context.Users.Add(user);
        _context.SaveChanges();

        return Ok(new { message = "User registered successfully" });
    }

    // ==============================
    // LOGIN
    // ==============================
    [HttpPost("login")]
    public IActionResult Login([FromBody] UserDto dto)
    {
        if (dto == null || string.IsNullOrWhiteSpace(dto.Username) || string.IsNullOrWhiteSpace(dto.Password))
            return BadRequest("Invalid data");

        var user = _context.Users
            .FirstOrDefault(u => u.Username == dto.Username && u.Password == dto.Password);

        if (user == null)
            return Unauthorized("Invalid credentials");

        // ✅ Get key from appsettings.json
        var keyString = _config["JwtKey"] ?? "THIS_IS_A_VERY_SECURE_KEY_123456789";
        var key = Encoding.UTF8.GetBytes(keyString);

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Username)
        };

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return Ok(new { token = jwt });
    }
}

// ==============================
// DTO
// ==============================
public class UserDto
{
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
}
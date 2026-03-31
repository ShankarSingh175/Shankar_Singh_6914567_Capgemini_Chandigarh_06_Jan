using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SecureAccountDetails.DTOs;
using SecureAccountDetails.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace SecureAccountDetails.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;

        // ✅ In-memory user store (NO DATABASE)
        private static List<User> users = new List<User>();

        public AuthController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDto dto)
        {
            if (users.Any(u => u.Username == dto.Username))
                return BadRequest("Username already exists.");

            // ✅ Strong secret key
            var secretKey = _config["Jwt:Key"] ?? "ThisIsMySuperSecretKey1234567890ABCDEF";

            // Hash password
            var passwordHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: dto.Password,
                salt: Encoding.UTF8.GetBytes(secretKey),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 32));

            var user = new User
            {
                Id = users.Count + 1,
                Username = dto.Username,
                PasswordHash = passwordHash
            };

            users.Add(user);

            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            var user = users.FirstOrDefault(u => u.Username == dto.Username);
            if (user == null)
                return Unauthorized("Invalid username or password.");

            // ✅ Same strong key
            var secretKey = _config["Jwt:Key"] ?? "ThisIsMySuperSecretKey1234567890ABCDEF";

            // Verify password
            var passwordHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: dto.Password,
                salt: Encoding.UTF8.GetBytes(secretKey),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 32));

            if (user.PasswordHash != passwordHash)
                return Unauthorized("Invalid username or password.");

            // 🔐 Generate JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = _config["Jwt:Issuer"] ?? "SecureAccountDetailsAPI",
                Audience = _config["Jwt:Audience"] ?? "SecureAccountUsers",
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwt = tokenHandler.WriteToken(token);

            return Ok(new { token = jwt });
        }
    }
}
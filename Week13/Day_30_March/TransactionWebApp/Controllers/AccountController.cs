using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;

public class AccountController : Controller
{
    private readonly IHttpClientFactory _clientFactory;

    public AccountController(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    // GET: /Account/Login
    public IActionResult Login() => View();

    // GET: /Account/Register
    public IActionResult Register() => View();

    // POST: /Account/Login
    [HttpPost]
    public async Task<IActionResult> Login(string username, string password)
    {
        var client = _clientFactory.CreateClient("ApiClient");

        var payload = new { username, password };
        var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

        var response = await client.PostAsync("Auth/login", content);
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var tokenObj = JsonSerializer.Deserialize<JsonElement>(json);
            var token = tokenObj.GetProperty("token").GetString();

            HttpContext.Session.SetString("JWToken", token);
            return RedirectToAction("Index", "Transactions");
        }

        ViewBag.Error = "Invalid credentials";
        return View();
    }

    // POST: /Account/Register
    [HttpPost]
    public async Task<IActionResult> Register(string username, string password)
    {
        var client = _clientFactory.CreateClient("ApiClient");

        var payload = new { username, password };
        var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

        var response = await client.PostAsync("Auth/register", content);
        if (response.IsSuccessStatusCode)
        {
            TempData["Message"] = "Registration successful! Please login.";
            return RedirectToAction("Login");
        }

        ViewBag.Error = "Username already exists";
        return View();
    }
}
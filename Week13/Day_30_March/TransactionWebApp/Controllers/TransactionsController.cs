using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

public class TransactionsController : Controller
{
    private readonly IHttpClientFactory _clientFactory;

    public TransactionsController(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var token = HttpContext.Session.GetString("JWToken");
        if (string.IsNullOrEmpty(token)) return RedirectToAction("Login", "Account");

        var client = _clientFactory.CreateClient("ApiClient");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await client.GetAsync("Transactions");
        if (!response.IsSuccessStatusCode) return View("Error");

        var json = await response.Content.ReadAsStringAsync();
        var transactions = JsonSerializer.Deserialize<List<TransactionViewModel>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        return View(transactions);
    }
}

public class TransactionViewModel
{
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string Type { get; set; }
}
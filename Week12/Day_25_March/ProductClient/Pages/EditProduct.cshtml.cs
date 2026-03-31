using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using ProductClient.Models;
public class EditProductModel : PageModel
{
    private readonly IHttpClientFactory _clientFactory;

    public EditProductModel(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    [BindProperty]
    public Product Product { get; set; } = new();

    public async Task OnGetAsync(int id)
    {
        var client = _clientFactory.CreateClient("ProductApi");

        var response = await client.GetAsync($"products/{id}");

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            Product = JsonSerializer.Deserialize<Product>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var client = _clientFactory.CreateClient("ProductApi");

        await client.PutAsJsonAsync($"products/{Product.Id}", Product);

        return RedirectToPage("/Products");
    }
}
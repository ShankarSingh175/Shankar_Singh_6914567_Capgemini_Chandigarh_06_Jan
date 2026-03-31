using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Net.Http.Json;
using ProductClient.Models;

namespace ProductClient.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public ProductsModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        // This holds data for UI
        public List<Product> Products { get; set; } = new();

        // Bind form inputs
        [BindProperty]
        public string Name { get; set; } = string.Empty;

        [BindProperty]
        public decimal Price { get; set; }

        // GET: Load products
        public async Task OnGetAsync()
        {
            Console.WriteLine("Fetching products from API...");
            var client = _clientFactory.CreateClient("ProductApi");

            var response = await client.GetAsync("products");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                Products = JsonSerializer.Deserialize<List<Product>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new();
            }
            
        }

        // POST: Add product
        public async Task<IActionResult> OnPostAsync()
        {
            var client = _clientFactory.CreateClient("ProductApi");

            var product = new Product
            {
                Name = Name,
                Price = Price
            };

            await client.PostAsJsonAsync("products", product);

            return RedirectToPage();
        }

        // POST: Delete product
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var client = _clientFactory.CreateClient("ProductApi");

            await client.DeleteAsync($"products/{id}");

            return RedirectToPage();
        }
    }
}
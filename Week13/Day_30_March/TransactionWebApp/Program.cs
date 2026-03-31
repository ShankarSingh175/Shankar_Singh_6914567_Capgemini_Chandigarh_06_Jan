using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using Microsoft.AspNetCore.DataProtection;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Data Protection for Session
builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo("/keys")) // Docker-friendly path
    .SetApplicationName("TransactionWebApp");

// 🔹 Add Controllers with Views
builder.Services.AddControllersWithViews();

// 🔹 Add HttpClient for API calls (use environment variable inside Docker)
var apiUrl = Environment.GetEnvironmentVariable("API_URL") ?? "http://host.docker.internal:5000/api/";
builder.Services.AddHttpClient("ApiClient", client =>
{
    client.BaseAddress = new Uri(apiUrl);
});

// 🔹 Enable Session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// 🔹 Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Disable HTTPS redirection in Docker
if (!app.Environment.IsEnvironment("Docker"))
{
    app.UseHttpsRedirection();
}

app.UseStaticFiles();
app.UseRouting();

// 🔐 Session must come before Auth
app.UseSession();

app.UseAuthorization();

// 🔹 Default controller route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

// 🔹 Run on port 5001 (Docker-friendly)
app.Urls.Clear();
app.Urls.Add("http://0.0.0.0:5001");

app.Run();
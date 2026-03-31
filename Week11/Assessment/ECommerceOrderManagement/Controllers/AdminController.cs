using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ECommerceOrderManagement.Data;
using ECommerceOrderManagement.ViewModels;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly ApplicationDbContext _context;

    public AdminController(
        ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult>
    UpdateShippingStatus(
    int id,
    string status)
    {
        var shipping =
            await _context.ShippingDetails
            .FindAsync(id);

        if (shipping != null)
        {
            shipping.Status = status;

            await _context.SaveChangesAsync();
        }

        return RedirectToAction("Dashboard");
    }

    public async Task<IActionResult> Dashboard()
    {
        // Top Products

        var topProducts =
            await _context.OrderItems
            .GroupBy(o => o.Product)
            .Select(g => new
            {
                Product = g.Key,
                Count = g.Sum(x => x.Quantity)
            })
            .OrderByDescending(x => x.Count)
            .Take(5)
            .Select(x => x.Product)
            .ToListAsync();


        // Pending Orders

        var pendingOrders =
            await _context.Orders
            .Include(o => o.Customer)
            .Include(o => o.ShippingDetail)
            .Where(o =>
                o.ShippingDetail != null &&
                o.ShippingDetail.Status == "Pending")
            .ToListAsync();


        // Shipped Orders

        var shippedOrders =
            await _context.Orders
            .Include(o => o.Customer)
            .Include(o => o.ShippingDetail)
            .Where(o =>
                o.ShippingDetail != null &&
                o.ShippingDetail.Status == "Shipped")
            .ToListAsync();


        // Delivered Orders

        var deliveredOrders =
            await _context.Orders
            .Include(o => o.Customer)
            .Include(o => o.ShippingDetail)
            .Where(o =>
                o.ShippingDetail != null &&
                o.ShippingDetail.Status == "Delivered")
            .ToListAsync();


        var vm = new DashboardViewModel
        {
            TopProducts = topProducts,

            PendingOrders = pendingOrders,

            ShippedOrders = shippedOrders,

            DeliveredOrders = deliveredOrders,

            TotalOrders = _context.Orders.Count(),

            TotalCustomers = _context.Customers.Count()
        };

        return View(vm);
    }
}
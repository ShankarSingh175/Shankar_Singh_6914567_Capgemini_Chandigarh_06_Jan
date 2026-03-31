using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using ECommerceOrderManagement.Data;
using ECommerceOrderManagement.Models;
using ECommerceOrderManagement.ViewModels;

namespace ECommerceOrderManagement.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var orders =
                _context.Orders
                .Include(o => o.Customer);

            return View(await orders.ToListAsync());
        }

        // GET: Orders/MyOrders
        public async Task<IActionResult> MyOrders()
        {
            var orders =
                await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .Include(o => o.ShippingDetail)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();

            return View(orders);
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var order =
                await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .Include(o => o.ShippingDetail)
                .FirstOrDefaultAsync(
                    o => o.OrderId == id);

            if (order == null)
                return NotFound();

            var vm =
                new OrderViewModel
                {
                    Order = order,
                    OrderItems = order.OrderItems.ToList(),
                    ShippingDetail = order.ShippingDetail
                };

            return View(vm);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            var vm =
                new OrderCreateViewModel
                {
                    Products =
                        _context.Products.ToList(),

                    Customers =
                        _context.Customers.ToList()
                };

            return View(vm);
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>
        Create(OrderCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                // Create Order

                var order =
                    new Order
                    {
                        CustomerId = vm.CustomerId,
                        OrderDate = DateTime.Now
                    };

                _context.Orders.Add(order);

                await _context.SaveChangesAsync();


                // Get Product

                var product =
                    await _context.Products
                    .FindAsync(vm.ProductId);


                // Create OrderItem

                var orderItem =
                    new OrderItem
                    {
                        OrderId = order.OrderId,
                        ProductId = vm.ProductId,
                        Quantity = vm.Quantity,
                        UnitPrice = product.Price
                    };

                _context.OrderItems.Add(orderItem);


                // Create Shipping

                var shipping =
                    new ShippingDetail
                    {
                        OrderId = order.OrderId,
                        Address = vm.Address,
                        City = vm.City,
                        PostalCode = vm.PostalCode,
                        Status = "Pending"
                    };

                _context.ShippingDetails.Add(shipping);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            vm.Products =
                _context.Products.ToList();

            vm.Customers =
                _context.Customers.ToList();

            return View(vm);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult>
        Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var order =
                await _context.Orders
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(
                    m => m.OrderId == id);

            if (order == null)
                return NotFound();

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost,
        ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>
        DeleteConfirmed(int id)
        {
            var order =
                await _context.Orders
                .FindAsync(id);

            if (order != null)
            {
                _context.Orders.Remove(order);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders
                .Any(e => e.OrderId == id);
        }
    }
}
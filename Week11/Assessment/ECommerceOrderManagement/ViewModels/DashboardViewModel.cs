using ECommerceOrderManagement.Models;

namespace ECommerceOrderManagement.ViewModels
{
    public class DashboardViewModel
    {
        public List<Product> TopProducts { get; set; }

        public List<Order> PendingOrders { get; set; }

        public List<Order> ShippedOrders { get; set; }

        public List<Order> DeliveredOrders { get; set; }

        public int TotalOrders { get; set; }

        public int TotalCustomers { get; set; }
    }
}
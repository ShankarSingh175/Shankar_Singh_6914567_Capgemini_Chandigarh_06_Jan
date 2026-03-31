using ECommerceOrderManagement.Models;

namespace ECommerceOrderManagement.ViewModels
{
    public class OrderViewModel
    {
        public Order Order { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        public ShippingDetail ShippingDetail { get; set; }
    }
}

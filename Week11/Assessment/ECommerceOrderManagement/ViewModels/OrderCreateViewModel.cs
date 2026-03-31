using ECommerceOrderManagement.Models;

namespace ECommerceOrderManagement.ViewModels
{
    public class OrderCreateViewModel
    {
        public int CustomerId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public List<Product>? Products { get; set; }

        public List<Customer>? Customers { get; set; }
    }
}
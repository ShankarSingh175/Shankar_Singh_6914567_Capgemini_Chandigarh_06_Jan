using System.ComponentModel.DataAnnotations;

namespace ECommerceOrderManagement.Models
{
    public class ShippingDetail
    {
        public int ShippingDetailId { get; set; }

        public int OrderId { get; set; }

        public Order? Order { get; set; }

        [Required]
        public string Address { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string Status { get; set; }
    }
}
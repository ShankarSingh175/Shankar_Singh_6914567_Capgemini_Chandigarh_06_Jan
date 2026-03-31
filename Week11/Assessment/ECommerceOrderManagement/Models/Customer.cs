using System.ComponentModel.DataAnnotations;

namespace ECommerceOrderManagement.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(15)]
        public string Phone { get; set; }

        public ICollection<Order>? Orders { get; set; }
    }
}
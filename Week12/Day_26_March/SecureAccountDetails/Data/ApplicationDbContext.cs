using Microsoft.EntityFrameworkCore;
using SecureAccountDetails.Models;  // Make sure this using exists

namespace SecureAccountDetails.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet for accounts
        public DbSet<Accounts> Accounts { get; set; } = null!;

        // DbSet for users (for authentication)
        public DbSet<User> Users { get; set; } = null!;
    }
}
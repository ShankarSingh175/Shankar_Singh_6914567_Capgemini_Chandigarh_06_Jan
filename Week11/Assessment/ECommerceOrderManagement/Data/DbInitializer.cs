using Microsoft.AspNetCore.Identity;

namespace ECommerceOrderManagement.Data
{
    public class DbInitializer
    {
        public static async Task SeedRolesAndAdminAsync(
            IServiceProvider serviceProvider)
        {
            var roleManager =
                serviceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();

            var userManager =
                serviceProvider
                .GetRequiredService<UserManager<IdentityUser>>();

            // Create Admin Role

            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(
                    new IdentityRole("Admin"));
            }

            // Create Admin User

            string adminEmail = "admin@gmail.com";

            var adminUser =
                await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                var newAdmin = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(
                    newAdmin,
                    "Admin@123");

                await userManager.AddToRoleAsync(
                    newAdmin,
                    "Admin");
            }
        }
    }
}
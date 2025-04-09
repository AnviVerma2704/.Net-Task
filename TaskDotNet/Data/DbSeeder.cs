using Microsoft.AspNetCore.Identity;
using TaskDotNet.Entities.IdentityEntities;
using TaskDotNet.Models;

namespace TaskDotNet.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            var roles = new[]
            {
                new ApplicationRole { Name = "Admin", Description = "Has full access" },
                new ApplicationRole { Name = "Employee", Description = "Limited access" }
            };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role.Name!))
                {
                    await roleManager.CreateAsync(role);
                }
            }

            var users = new[]
            {
                new { UserName = "admin1", Email = "admin1@domain.com", Password = "Admin@123", Role = "Admin" },
                new { UserName = "admin2", Email = "admin2@domain.com", Password = "Admin@123", Role = "Admin" },
                new { UserName = "employee1", Email = "employee1@domain.com", Password = "Employee@123", Role = "Employee" },
                new { UserName = "employee2", Email = "employee2@domain.com", Password = "Employee@123", Role = "Employee" },
                new { UserName = "employee3", Email = "employee3@domain.com", Password = "Employee@123", Role = "Employee" },
                new { UserName = "employee4", Email = "employee4@domain.com", Password = "Employee@123", Role = "Employee" }
            };

            foreach (var u in users)
            {
                var existingUser = await userManager.FindByNameAsync(u.UserName);
                if (existingUser == null)
                {
                    var user = new ApplicationUser { UserName = u.UserName, Email = u.Email, EmailConfirmed = true };
                    await userManager.CreateAsync(user, u.Password);
                    await userManager.AddToRoleAsync(user, u.Role);
                }
            }
        }
    }
}

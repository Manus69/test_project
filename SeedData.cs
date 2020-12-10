using System;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;
using AspNetCoreTodo.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace AspNetCoreTodo
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider services)
        {
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            await EnsureRolesAsync(roleManager);

            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            await EnsureTestAdminAsync(userManager);
        }
        private static async Task EnsureRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            var alreadyExists = await roleManager.RoleExistsAsync(Constants.AdministratorRole);

            if (alreadyExists)
                return;
            await roleManager.CreateAsync(
            new IdentityRole(Constants.AdministratorRole));
        }

        private static async Task EnsureTestAdminAsync(UserManager<ApplicationUser> userManager)
        {
            // "admin@todo.local"
            var testAdmin = await userManager.Users
            .Where(x => x.UserName == "admin@todo")
            .SingleOrDefaultAsync();
        
            if (testAdmin != null)
                return;

            testAdmin = new ApplicationUser
            {
                UserName = "admin@todo",
                Email = "admin@todo",
                EmailConfirmed = true
            };
            
            await userManager.CreateAsync(testAdmin, "admin123");
            await userManager.AddToRoleAsync(testAdmin, Constants.AdministratorRole);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence
{
    public class DbInitializer(LoanSystemDbContext context,UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager) : IDbInitializer
    {
       
        public async Task InitializeAsync()
        {
            if(context.Database.GetPendingMigrations().Any())
            {
                await context.Database.MigrateAsync();
            }

            if (!roleManager.Roles.Any())
            {
                var AdminRole = new IdentityRole()
                { Name = "Admin" };
                var UserRole = new IdentityRole()
                { Name = "User"};
                await roleManager.CreateAsync(AdminRole);
                await roleManager.CreateAsync(UserRole);
            }

            if(!userManager.Users.Any())
            {
                var user1 = new AppUser()
                {
                    Email = "sasa@gamil.com",
                    UserName = "Sasa",
                    PhoneNumber = "1234567890",
                };

                var user2 = new AppUser()
                {
                    Email = "honda@gamil.com",
                    UserName = "Honda",
                    PhoneNumber = "1234567890",
                };

                await userManager.CreateAsync(user1,"p@ssW0rd");
                await userManager.CreateAsync(user2,"p@ssW0rd");

                await userManager.AddToRoleAsync(user1, "User");
                await userManager.AddToRoleAsync(user2, "User");
            }

            if (!context.Loans.Any())
            {
                var loan = new Loan()
                {
                    Amount = 2000,
                    BorrowerId = "925fc1e6-5c9e-4969-bcad-1be2169d2e1f",
                    LenderId = "95457d32-a933-41cc-b44a-6f737b1bbbd1",
                    DueDate = DateTime.Parse("5/12/2025"),
                };
                await context.AddAsync(loan);
                await context.SaveChangesAsync();
            }
        }
    }
}

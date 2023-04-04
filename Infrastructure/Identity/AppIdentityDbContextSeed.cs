using Core.Entiies.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Ty",
                    Email = "ty@test.com",
                    UserName = "ty@test.com",
                    Address = new Address
                    {
                        Name = "Ty",
                        Street = "Vinh Hoi",
                        City = "Sai Gon",
                        State = "South",
                        Zipcode = "70000"
                    }
                };
                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}

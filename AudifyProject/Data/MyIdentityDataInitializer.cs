using AudifyProject.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudifyProject.Data
{
    public class MyIdentityDataInitializer
    {

        public static void SeedData(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)

        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }
        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByEmailAsync("admin@gmail.com").Result == null)
            {
                ApplicationUser appUser = new ApplicationUser()
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",

                };
                IdentityResult result = userManager.CreateAsync(appUser, "P@ger123").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(appUser, "Admin").Wait();
                }
            }

            
            

        }
        public static void SeedRoles(RoleManager<ApplicationRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                ApplicationRole role = new ApplicationRole()
                {
                    Name = "Admin",
                    NormalizedName = "Admin"

                };
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync("Manager").Result)
            {
                ApplicationRole role = new ApplicationRole()
                {
                    Name = "Manager",
                    NormalizedName = "Manager"


                };
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
           
            if (!roleManager.RoleExistsAsync("User").Result)
            {
                ApplicationRole role = new ApplicationRole()
                {
                    Name = "User",
                    NormalizedName = "User"

                };
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }

        }
    }
}

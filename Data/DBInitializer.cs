using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PetClinic.Data
{
    public static class DBInitializer
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider
                .GetRequiredService<ApplicationDbContext>();
            context.Database.EnsureCreated();
            var roleManager = serviceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();

            string[] RoleNames = { "Admin", "Owner", "Vet" };

            foreach (string roleName in RoleNames)
            {
                IdentityResult result;
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    result = await roleManager
                        .CreateAsync(new IdentityRole(roleName));
                }
            }
        }
    }
}

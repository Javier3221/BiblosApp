using BiblosApp.Core.Application.Enums;
using BiblosApp.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblosApp.Infrastructure.Identity.Seeds
{
    public static class ClientePorDefecto
    {
        public static async Task SeedAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            AppUser defaultUser = new();

            defaultUser.Nombre = "Usuario";
            defaultUser.Apellido = "Por Defecto";
            defaultUser.UserName = "DefaultUser";
            defaultUser.Email = "cliente@gmail.com";
            defaultUser.EmailConfirmed = true;
            defaultUser.PhoneNumberConfirmed = true;

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    var result = await userManager.CreateAsync(defaultUser, "123Contra$ena");
                    if (!result.Succeeded) 
                    {
                        Console.WriteLine(result.Errors);
                    }
                    else
                    {
                        Console.WriteLine(result.ToString());
                    }
                    await userManager.AddToRoleAsync(defaultUser, RolesUsuario.Cliente.ToString());
                }
            }
        }
    }
}

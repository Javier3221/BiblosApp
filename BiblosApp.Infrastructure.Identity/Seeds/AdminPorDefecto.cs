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
    public static class AdminPorDefecto
    {
        public static async Task SeedAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            AppUser defaultUser = new();

            defaultUser.Nombre = "Usuario";
            defaultUser.Apellido = "Por Defecto";
            defaultUser.UserName = "DefaultAdmin";
            defaultUser.Email = "example@email.com";
            defaultUser.EmailConfirmed = true;
            defaultUser.PhoneNumberConfirmed = true;

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Contra$ena");
                    await userManager.AddToRoleAsync(defaultUser, RolesUsuario.Administrativo.ToString());
                }
            }
        }
    }
}

using BiblosApp.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiblosApp.Core.Application.Enums;

namespace BiblosApp.Infrastructure.Identity.Seeds
{
    public static class RolesPorDefecto
    {
        public static async Task SeedAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(RolesUsuario.Administrativo.ToString()));
            await roleManager.CreateAsync(new IdentityRole(RolesUsuario.Cliente.ToString()));
        }
    }
}

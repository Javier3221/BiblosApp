using BiblosApp.Core.Application.DTOs.Account;
using BiblosApp.Core.Application.Enums;
using BiblosApp.Core.Application.Helpers;
using BiblosApp.Core.Application.Interfaces.Servicios;
using BiblosApp.Core.Application.ViewModels.Usuario;
using BiblosApp.Models.Middlewares;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BiblosApp.Controllers
{
    public class UserController : Controller
    {
        public IUserService _servicio;
        public UserController(IUserService servicio)
        {
            _servicio = servicio;
        }

        [ServiceFilter(typeof(AutorizarSesion))]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [ServiceFilter(typeof(AutorizarSesion))]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            AuthenticationResponse response = await _servicio.LoginAsync(vm);
            if (response.HasError || response == null)
            {
                vm.HasError = response.HasError;
                vm.Error = response.Error;
                return View(vm);
            }

            HttpContext.Session.Set<AuthenticationResponse>("user", response);
            if (response.Roles.Contains(RolesUsuario.Cliente.ToString()))
            {
                return RedirectToRoute(new { controller = "Client", action = "Index" });
            }
            if (response.Roles.Contains(RolesUsuario.Administrativo.ToString()))
            {
                return RedirectToRoute(new { controller = "Admin", action = "Index" });
            }

            vm.HasError = true;
            vm.Error = "Tu cuenta no puede acceder en este momento";
            return View(vm);
        }

        [ServiceFilter(typeof(AutorizarSesion))]
        public IActionResult Register()
        {
            return View(new UsuarioSaveViewModel());
        }

        [ServiceFilter(typeof(AutorizarSesion))]
        [HttpPost]
        public async Task<IActionResult> Register(UsuarioSaveViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var origin = Request.Headers["Origin"];
            vm.Rol = RolesUsuario.Cliente.ToString();

            RegisterResponse Clienteresponse = await _servicio.RegisterAsync(vm.Rol, vm, origin: origin);

            if (Clienteresponse.HasError)
            {
                vm.HasError = Clienteresponse.HasError;
                vm.Error = Clienteresponse.Error;
                return View(vm);
            }
            
            return RedirectToRoute(new { controller = "User", action = "Login" });
        }

        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            await _servicio.SignOutAsync();
            HttpContext.Session.Remove("user");
            return RedirectToRoute(new { controller = "User", action = "Login" });
        }
    }
}

using BiblosApp.Core.Application.DTOs.Account;
using BiblosApp.Core.Application.Enums;
using BiblosApp.Core.Application.Interfaces.Servicios;
using BiblosApp.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblosApp.Infrastructure.Identity.Service
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountService(UserManager<AppUser> userManager, 
            SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
        {
            AuthenticationResponse response = new();

            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                response.HasError = true;
                response.Error = $"No hay cuentas registradas con {request.Email}";
                return response;
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Contrasena, false, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                response.HasError = true;
                response.Error = $"Contraseña inválida para la cuenta {request.Email}";
                return response;
            }
            if (!user.EmailConfirmed)
            {
                var roles = await _userManager.GetRolesAsync(user).ConfigureAwait(false);

                if (roles.Contains("Cliente"))
                {
                    response.HasError = true;
                    response.Error = $"La cuenta de {request.Email} no ha sido activada, revisa tu correo para activarla";
                    return response;
                }

                response.HasError = true;
                response.Error = $"La cuenta de {request.Email} no ha sido confirmada, ponte en contacto con un administrador para activarla";
                return response;
            }

            response.Id = user.Id;
            response.Email = user.Email;
            response.UserName = user.UserName;

            var rolesList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);

            response.Roles = rolesList.ToList();
            user.EmailConfirmed = true;

            return response;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<RegisterResponse> RegisterUserAsync(RegisterRequest request, string rol, string origin = "")
        {
            RegisterResponse response = new()
            {
                HasError = false
            };

            var userWithSameUserName = await _userManager.FindByNameAsync(request.UserName);
            if (userWithSameUserName != null)
            {
                response.HasError = true;
                response.Error = $"Nombre de usuario '{request.UserName}' ocupado.";
                return response;
            }

            var userWithSameEmail = await _userManager.FindByEmailAsync(request.Email);
            if (userWithSameEmail != null)
            {
                response.HasError = true;
                response.Error = $"Email '{request.Email}' ya está registrado.";
                return response;
            }

            var user = new AppUser
            {
                Email = request.Email,
                Nombre = request.Nombre,
                Apellido = request.Apellido,
                UserName = request.UserName
            };

            var result = await _userManager.CreateAsync(user, request.Contrasena);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, rol);

                var token = await GenerarTokenRegistroUsuario(user);
                await _userManager.ConfirmEmailAsync(user, token);
            }
            else
            {
                response.HasError = true;
                response.Error = $"Ocurrió un error tratando de registrar el usuario.";
            }

            return response;
        }



        private async Task<string> GenerarTokenRegistroUsuario(AppUser user)
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            return code;
        }
    }
}

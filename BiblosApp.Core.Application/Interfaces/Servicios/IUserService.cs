using BiblosApp.Core.Application.DTOs.Account;
using BiblosApp.Core.Application.ViewModels.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblosApp.Core.Application.Interfaces.Servicios
{
    public interface IUserService
    {
        Task<AuthenticationResponse> LoginAsync(LoginViewModel vm);
        Task SignOutAsync();
        Task<RegisterResponse> RegisterAsync(string rol, UsuarioSaveViewModel userVm = null, string origin = "");
    }
}

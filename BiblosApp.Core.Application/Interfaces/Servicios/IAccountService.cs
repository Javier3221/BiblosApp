using BiblosApp.Core.Application.DTOs.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblosApp.Core.Application.Interfaces.Servicios
{
    public interface IAccountService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task SignOutAsync();
        Task<RegisterResponse> RegisterUserAsync(RegisterRequest request, string rol, string origin = "");
    }
}

using BiblosApp.Core.Application.DTOs.Account;
using Microsoft.AspNetCore.Http;

namespace BiblosApp.Models.Middlewares
{
    public class ValidarSesion
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ValidarSesionIniciada(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool HaySesion()
        {
            AuthenticationResponse user = _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");

            return user != null;
        }
    }
}

using BiblosApp.Core.Application.DTOs.Account;
using BiblosApp.Core.Application.Helpers;
using Microsoft.AspNetCore.Http;

namespace BiblosApp.Models.Middlewares
{
    public class ValidarSesion
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ValidarSesion(IHttpContextAccessor httpContextAccessor)
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

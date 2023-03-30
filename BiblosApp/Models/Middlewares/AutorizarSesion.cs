using BiblosApp.Controllers;
using BiblosApp.Core.Application.DTOs.Account;
using BiblosApp.Core.Application.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace BiblosApp.Models.Middlewares
{
    public class AutorizarSesion : IAsyncActionFilter
    {
        private readonly ValidarSesion _validar;
        private readonly AuthenticationResponse user;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AutorizarSesion(ValidarSesion validar, IHttpContextAccessor httpContextAccessor)
        {
            _validar = validar;
            _httpContextAccessor = httpContextAccessor;
            user = _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (_validar.HaySesion())
            {
                var controller = (UserController)context.Controller;
                if (user.Roles.Contains("Administrativo"))
                {
                    context.Result = controller.RedirectToAction("Index", "Admin");
                }
                else
                {
                    context.Result = controller.RedirectToAction("Index", "Cliente");
                }
            }
            else
            {
                await next();
            }
        }
    }
}
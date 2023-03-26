using BiblosApp.Core.Application.ViewModels.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace BiblosApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }
    }
}

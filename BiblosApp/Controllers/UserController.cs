using Microsoft.AspNetCore.Mvc;

namespace BiblosApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

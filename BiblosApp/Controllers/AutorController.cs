using BiblosApp.Core.Application.Interfaces.Servicios;
using BiblosApp.Core.Application.ViewModels.Autor;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BiblosApp.Controllers
{
    public class AutorController : Controller
    {
        private readonly IAutorService _autorService;

        public AutorController(IAutorService autorService)
        {
            _autorService = autorService;
        }

        public IActionResult AgregarAutor()
        {
            return View(new AutorSaveViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> AgregarAutor(AutorSaveViewModel sVM)
        {
            if (!ModelState.IsValid)
            {
                return View(sVM);
            }

            await _autorService.Agregar(sVM);

            return RedirectToRoute(new { controller="Admin", action="Index"});
        }
    }
}

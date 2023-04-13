using BiblosApp.Core.Application.Helpers;
using BiblosApp.Core.Application.Interfaces.Servicios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BiblosApp.Controllers
{
    [Authorize(Roles = "Cliente")]
    public class ClienteController : Controller
    {
        public readonly ILibroService _libroService;
        public ClienteController(ILibroService libroService)
        {
            _libroService = libroService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ComprarLibro(List<int> libros)
        {
            List<string> notInStock = await _libroService.ComprarLibros(libros);
            if (notInStock.Count > 0)
            {
                TempData.Put("notInStock", notInStock);
            }

            return RedirectToAction("Index");
        }
    }
}

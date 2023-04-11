using BiblosApp.Core.Application.Interfaces.Servicios;
using BiblosApp.Core.Application.ViewModels.Libro;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BiblosApp.Controllers
{
    [Authorize(Roles = "Administrativo")]
    public class AdminController : Controller
    {
        private readonly ILibroService _libroService;
        private readonly IAutorService _autorService;
        public AdminController(ILibroService libroService, IAutorService autorService) 
        {
            _libroService = libroService;
            _autorService = autorService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _libroService.ObtenerIncludes());
        }

        public async Task<IActionResult> CrearLibro()
        {
            ViewData["isEdit"] = false;
            LibroSaveViewModel saveViewModel = new();
            saveViewModel.ListadoAutores = await _autorService.ObtenerTodos();
            return View("SaveLibro", saveViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CrearLibro(LibroSaveViewModel sVM)
        {
            
            if (!ModelState.IsValid)
            {
                ViewData["isEdit"] = false;
                LibroSaveViewModel saveViewModel = new();
                saveViewModel.ListadoAutores = await _autorService.ObtenerTodos();
                return View("SaveLibro", saveViewModel);
            }

            await _libroService.Agregar(sVM);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditarLibro(int id)
        {
            ViewData["isEdit"] = true;
            LibroSaveViewModel saveViewModel = await _libroService.ObtenerPorIdSaveViewModel(id);
            saveViewModel.ListadoAutores = await _autorService.ObtenerTodos();
            return View("SaveLibro", saveViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditarLibro(LibroSaveViewModel sVM)
        {
            if (!ModelState.IsValid)
            {
                ViewData["isEdit"] = true;
                LibroSaveViewModel saveViewModel = await _libroService.ObtenerPorIdSaveViewModel(sVM.Id);
                saveViewModel.ListadoAutores = await _autorService.ObtenerTodos();
                return View("SaveLibro", saveViewModel);
            }

            await _libroService.Editar(sVM, sVM.Id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EliminarLibro(int id)
        {
            await _libroService.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}

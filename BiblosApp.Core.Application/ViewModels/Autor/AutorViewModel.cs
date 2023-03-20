using BiblosApp.Core.Application.ViewModels.Libro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblosApp.Core.Application.ViewModels.Autor
{
    public class AutorViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Num_publicaciones { get; set; }

        public List<LibroViewModel> Libros { get; set; } = new();
    }
}

using BiblosApp.Core.Application.ViewModels.Libro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblosApp.Core.Application.Interfaces.Servicios
{
    public interface ILibroService : IGenericService<LibroSaveViewModel, LibroViewModel>
    {
            
    }
}

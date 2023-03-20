using BiblosApp.Core.Application.ViewModels.Autor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblosApp.Core.Application.Interfaces.Servicios
{
    public interface IAutorService : IGenericService<AutorSaveViewModel, AutorViewModel>
    {
    }
}

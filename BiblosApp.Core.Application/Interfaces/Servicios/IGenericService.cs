using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblosApp.Core.Application.Interfaces.Servicios
{
    public interface IGenericService<SaveViewModel, ViewModel>
    {
        Task<SaveViewModel> Agregar(SaveViewModel vm);
        Task Editar(SaveViewModel vm, int id);
        Task Eliminar(int id);
        Task<SaveViewModel> ObtenerPorIdSaveViewModel(int id);
        Task<ViewModel> ObtenerPorIdViewModel(int id);
        Task<List<ViewModel>> ObtenerTodos();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblosApp.Core.Application.Interfaces.Repositorios
{
    public interface IGenericRepository<Entity>
    {
        Task<Entity> AgregarAsync(Entity entity);
        Task<Entity> EditarAsync(Entity entity, int id);
        Task EliminarAsync(Entity entity);
        Task<List<Entity>> ObtenerEntidades();
        Task<List<Entity>> GetAllWithIncludeAsync(List<string> properties);
        Task<Entity> ObtenerPorIdAsync(int id);
    }
}

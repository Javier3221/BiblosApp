using BiblosApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblosApp.Core.Application.Interfaces.Repositorios
{
    public interface ILibroRepository : IGenericRepository<Libro>
    {
        Task<List<Libro>> GetByTitle(string title);
    }
}

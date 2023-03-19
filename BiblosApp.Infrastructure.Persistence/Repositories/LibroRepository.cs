using BiblosApp.Core.Application.Interfaces.Repositorios;
using BiblosApp.Core.Domain.Entities;
using BiblosApp.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblosApp.Infrastructure.Persistence.Repositories
{
    internal class LibroRepository : GenericRepository<Libro>, ILibroRepository
    {
        private ApplicationContext _dbContext;
        public LibroRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}

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
    public class AutorRepository : GenericRepository<Autor>, IAutorRepository
    {
        private ApplicationContext _dbContext;

        public AutorRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


    }
}

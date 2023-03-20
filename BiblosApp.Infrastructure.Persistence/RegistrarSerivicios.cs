using BiblosApp.Core.Application.Interfaces.Repositorios;
using BiblosApp.Infrastructure.Persistence.Contexts;
using BiblosApp.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblosApp.Infrastructure.Persistence
{
    public static class RegistrarSerivicios
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection servicios, IConfiguration configuracion)
        {
            #region Context

            servicios.AddDbContext<ApplicationContext>(opciones =>
            opciones.UseSqlServer(configuracion.GetConnectionString("ConexionPorDefecto"),
            m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));

            #endregion

            #region Repositorios

            servicios.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            servicios.AddTransient<IAutorRepository, AutorRepository>();
            servicios.AddTransient<ILibroRepository, LibroRepository>();

            #endregion
        }
    }
}

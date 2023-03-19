using BiblosApp.Infrastructure.Persistence.Contexts;
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
        }
    }
}

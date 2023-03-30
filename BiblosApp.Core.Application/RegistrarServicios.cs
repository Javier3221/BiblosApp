using BiblosApp.Core.Application.Interfaces.Repositorios;
using BiblosApp.Core.Application.Interfaces.Servicios;
using BiblosApp.Core.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BiblosApp.Core.Application
{
    public static class RegistrarServicios
    {
        public static void AddAplicationLayer(this IServiceCollection services, IConfiguration config)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            #region Servicios

            services.AddTransient(typeof(IGenericService<,>), typeof(GenericService<,,>));
            services.AddTransient<ILibroService, LibroService>();
            services.AddTransient<IAutorService, AutorService>();
            services.AddTransient<IUserService, UserService>();

            #endregion
        }
    }
}

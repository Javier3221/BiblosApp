using AutoMapper;
using BiblosApp.Core.Application.Interfaces.Repositorios;
using BiblosApp.Core.Application.Interfaces.Servicios;
using BiblosApp.Core.Application.ViewModels.Libro;
using BiblosApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblosApp.Core.Application.Services
{
    public class LibroService : GenericService<LibroSaveViewModel, LibroViewModel, Libro>, ILibroService
    {
        private readonly ILibroRepository _libroRepository;
        private readonly IMapper _mapper;

        public LibroService(ILibroRepository libroRepository, IMapper mapper) : base(libroRepository, mapper) 
        {
            _libroRepository = libroRepository;
            _mapper = mapper;
        }

        public virtual async Task<List<LibroViewModel>> ObtenerIncludes()
        {
            return _mapper.Map<List<LibroViewModel>>(await _libroRepository.GetAllWithIncludeAsync(new List<string> { "Autor" }));
        }

        public async Task<List<LibroViewModel>> GetByTitle(string title)
        {
            return _mapper.Map<List<LibroViewModel>>(await _libroRepository.GetByTitle(title));
        }

        public async Task<List<string>> ComprarLibros(List<int> libros)
        {
            List<string> notInStock = new();
            foreach (int id in libros)
            {
                var libro = await base.ObtenerPorIdViewModel(id);
                if (libro.Cantidad_inventario > 0)
                {
                    libro.Cantidad_inventario -= 1;
                    await base.Editar(_mapper.Map<LibroSaveViewModel>(libro), libro.Id);
                }
                else
                {
                    notInStock.Add(libro.Nombre);
                }
            }

            return notInStock;
        }
    }
}

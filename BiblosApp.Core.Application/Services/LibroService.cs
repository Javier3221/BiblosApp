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
    }
}

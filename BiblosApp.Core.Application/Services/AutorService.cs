using AutoMapper;
using BiblosApp.Core.Application.Interfaces.Repositorios;
using BiblosApp.Core.Application.Interfaces.Servicios;
using BiblosApp.Core.Application.ViewModels.Autor;
using BiblosApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblosApp.Core.Application.Services
{
    public class AutorService : GenericService<AutorSaveViewModel, AutorViewModel, Autor>, IAutorService
    {
        private readonly IAutorRepository _autorRepository;
        private readonly IMapper _mapper;

        public AutorService(IAutorRepository autorRepository, IMapper mapper) : base(autorRepository, mapper)
        {
            _autorRepository = autorRepository;
            _mapper = mapper;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BiblosApp.Core.Application.DTOs.Account;
using BiblosApp.Core.Application.ViewModels.Autor;
using BiblosApp.Core.Application.ViewModels.Libro;
using BiblosApp.Core.Application.ViewModels.Usuario;
using BiblosApp.Core.Domain.Entities;

namespace BiblosApp.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile() 
        {
            CreateMap<LibroSaveViewModel, Libro>()
                .ForMember(x => x.CreadoPor, opt => opt.Ignore())
                .ForMember(x => x.FechaCreado, opt => opt.Ignore())
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.Autor, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<LibroViewModel, Libro>()
                .ForMember(x => x.CreadoPor, opt => opt.Ignore())
                .ForMember(x => x.FechaCreado, opt => opt.Ignore())
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.Autor, opt => opt.MapFrom(k => k.Autor))
                .ForMember(x => x.Id_autor, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(x => x.Autor, opt => opt.MapFrom(k => k.Autor));

            CreateMap<AutorSaveViewModel, Autor>()
                .ForMember(x => x.CreadoPor, opt => opt.Ignore())
                .ForMember(x => x.FechaCreado, opt => opt.Ignore())
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.Libros, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<AutorViewModel, Autor>()
                .ForMember(x => x.CreadoPor, opt => opt.Ignore())
                .ForMember(x => x.FechaCreado, opt => opt.Ignore())
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.Libros, opt => opt.MapFrom(k => k.Libros))
                .ReverseMap()
                .ForMember(x => x.Libros, opt => opt.MapFrom(k => k.Libros));

            CreateMap<LoginViewModel, AuthenticationRequest>()
                .ReverseMap()
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ForMember(x => x.HasError, opt => opt.Ignore());

        }
    }
}

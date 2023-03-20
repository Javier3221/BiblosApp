using AutoMapper;
using BiblosApp.Core.Application.Interfaces.Repositorios;
using BiblosApp.Core.Application.Interfaces.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblosApp.Core.Application.Services
{
    public class GenericService<SaveViewModel, ViewModel, Entity> : IGenericService<SaveViewModel, ViewModel>
        where SaveViewModel : class
        where ViewModel : class
        where Entity : class
    {
        private readonly IGenericRepository<Entity> _genericRepository;
        private readonly IMapper _mapper;

        public GenericService(IGenericRepository<Entity> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public virtual async Task<SaveViewModel> Agregar(SaveViewModel vm)
        {
            Entity entity = _mapper.Map<Entity>(vm);
            SaveViewModel saveVm = _mapper.Map<SaveViewModel>(await _genericRepository.AgregarAsync(entity));
            return saveVm;
        }

        public virtual async Task Editar(SaveViewModel vm, int id)
        {
            Entity entity = _mapper.Map<Entity>(vm);
            await _genericRepository.EditarAsync(entity, id);
        }

        public virtual async Task Eliminar(int id)
        {
            var entity = await _genericRepository.ObtenerPorIdAsync(id);
            await _genericRepository.EliminarAsync(entity);
        }

        public virtual async Task<List<ViewModel>> ObtenerTodos()
        {
            return _mapper.Map<List<ViewModel>>(await _genericRepository.ObtenerEntidades());
        }

        public virtual async Task<ViewModel> ObtenerPorIdViewModel(int id)
        {
            return _mapper.Map<ViewModel>(await _genericRepository.ObtenerPorIdAsync(id));
        }

        public virtual async Task<SaveViewModel> ObtenerPorIdSaveViewModel(int id)
        {
            return _mapper.Map<SaveViewModel>(await _genericRepository.ObtenerPorIdAsync(id));
        }
    }
}

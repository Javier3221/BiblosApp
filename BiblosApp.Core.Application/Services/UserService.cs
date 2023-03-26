using AutoMapper;
using BiblosApp.Core.Application.DTOs.Account;
using BiblosApp.Core.Application.Helpers;
using BiblosApp.Core.Application.Interfaces.Servicios;
using BiblosApp.Core.Application.ViewModels.Usuario;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblosApp.Core.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AuthenticationResponse userViewModel;

        public UserService(IAccountService accountService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _accountService = accountService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            userViewModel = _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");
        }

        public async Task<AuthenticationResponse> LoginAsync(LoginViewModel vm)
        {
            AuthenticationRequest loginRequest = _mapper.Map<AuthenticationRequest>(vm);
            AuthenticationResponse userResponse = await _accountService.AuthenticateAsync(loginRequest);
            return userResponse;
        }
        public async Task SignOutAsync()
        {
            await _accountService.SignOutAsync();
        }

        public async Task<RegisterResponse> RegisterAsync(string rol, UsuarioSaveViewModel userVm = null, string origin = "")
        {
            RegisterRequest registerRequest = new();
            if (userVm != null)
            {
                registerRequest = _mapper.Map<RegisterRequest>(userVm);
            }

            if (origin == null || origin == "")
            {
                return await _accountService.RegisterUserAsync(registerRequest, rol);
            }
            return await _accountService.RegisterUserAsync(registerRequest, rol, origin);
        }
    }
}

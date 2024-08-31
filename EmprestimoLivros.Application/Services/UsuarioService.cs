using AutoMapper;
using BCrypt.Net;
using EmprestimoLivros.Application.DTOs;
using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Domain.Interfaces;

namespace EmprestimoLivros.Application.Services {

    public class UsuarioService : IUsuarioService {

        private readonly IUsuarioRepository _usuarioRepository;

        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper) {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<Usuario> Create(UsuarioDTO usuarioDTO) {
            var usuario = _mapper.Map<Usuario>(usuarioDTO);
            usuario.Password = BCrypt.Net.BCrypt.HashPassword(usuario.Password);
            var usuarioCriado = await _usuarioRepository.Create(usuario);
            return usuarioCriado;
        }

        public async Task<Usuario?> GetByEmail(string email) {
            var usuario = await _usuarioRepository.GetByEmail(email);
            return usuario;
        }

        public async Task<string?> Login(string email, string password) {
            var usuario = await _usuarioRepository.Login(email, password);
            return usuario;
        }
    }
}
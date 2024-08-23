using AutoMapper;
using BCrypt.Net;
using EmprestimoLivros.Application.DTOs;
using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoLivros.API.Controllers {
    
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase {

        private readonly IMapper _mapper;

        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository, IMapper mapper) {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> Create([FromBody] UsuarioDTO usuarioDTO) {
            var usuario = _mapper.Map<Usuario>(usuarioDTO);
            usuario.Password = BCrypt.Net.BCrypt.HashPassword(usuario.Password);
            
            var result = await _usuarioRepository.Create(usuario);
            if(result == null) return BadRequest();
            return Created();
        }

        [HttpPost("login")]
        public async Task<ActionResult<Usuario>> Login(string email, string password) {
            var usuario = await _usuarioRepository.Login(email, password);
            if(usuario == null) return Unauthorized();
            return Ok(usuario);
        }

    }
}
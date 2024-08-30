using EmprestimoLivros.Application.DTOs;
using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoLivros.API.Controllers {
    
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase {

        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService) {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> Create([FromBody] UsuarioDTO usuarioDTO) {
            var verificaSeUsuarioExiste = await _usuarioService.GetByEmail(usuarioDTO.Email);
            if(verificaSeUsuarioExiste != null) return Conflict("Já existe um usuário registrado com este e-mail!");

            var usuario = await _usuarioService.Create(usuarioDTO);
            if(usuario == null) return BadRequest("Ocorreu um erro ao tentar se cadastrar!");
            return Created();
        }

        [HttpPost("login")]
        public async Task<ActionResult<Usuario>> Login(string email, string password) {
            var usuario = await _usuarioService.Login(email, password);
            if(usuario == null) return Unauthorized("Acesso não autorizado!");
            return Ok(usuario);
        }

    }
}
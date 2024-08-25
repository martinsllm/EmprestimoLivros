using EmprestimoLivros.Application.DTOs;
using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoLivros.API.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class LivroController : ControllerBase {

        private readonly ILivroService _livroService;

        public LivroController(ILivroService livroService) {
            _livroService = livroService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<Livro>>> Get() {
            var livros = await _livroService.Get();
            return Ok(livros);
        }

        [HttpGet("id")]
        [Authorize]
        public async Task<ActionResult<List<Livro>>> GetById(int id) {
            var livro = await _livroService.GetById(id);
            if(livro == null) return NotFound();
            return Ok(livro);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Livro>> Create([FromBody] LivroDTO livroDTO) {
            var livro = await _livroService.Create(livroDTO);
            if(livro == null) return BadRequest();
            return Created();
        }

        [HttpPut("id")]
        [Authorize]
        public async Task<ActionResult<Livro>> Update([FromBody] LivroDTO livroDTO, int id) {
            var livro = await _livroService.Update(livroDTO, id);
            if(livro == null) return BadRequest();
            return NoContent();
        }

        [HttpDelete("id")]
        [Authorize]
        public async Task<ActionResult<Livro>> Remove(int id) {
            var livro = await _livroService.Remove(id);
            if(livro == null) return BadRequest();
            return NoContent();
        }

    }
}
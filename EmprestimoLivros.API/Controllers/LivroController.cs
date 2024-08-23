using AutoMapper;
using EmprestimoLivros.Application.DTOs;
using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoLivros.API.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class LivroController : ControllerBase {

        private readonly IEntityRepository<Livro> _livroRepository;

        private readonly IMapper _mapper;

        public LivroController(IEntityRepository<Livro> livroRepository, IMapper mapper) {
            _livroRepository = livroRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<Livro>>> Get() {
            var livros = await _livroRepository.Get();
            var livrosDTO = _mapper.Map<List<LivroDTO>>(livros);
            return Ok(livrosDTO);
        }

        [HttpGet("id")]
        [Authorize]
        public async Task<ActionResult<List<Livro>>> GetById(int id) {
            var livro = await _livroRepository.GetById(id);
            if(livro == null) return NotFound();
            var livroDTO = _mapper.Map<LivroDTO>(livro);
            return Ok(livroDTO);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Livro>> Create([FromBody] LivroDTO livroDTO) {
            var livro = _mapper.Map<Livro>(livroDTO);
            var result = await _livroRepository.Create(livro);
            if(result == null) return BadRequest();
            return Created();
        }

        [HttpPut("id")]
        [Authorize]
        public async Task<ActionResult<Livro>> Update([FromBody] LivroDTO livroDTO, int id) {
            var livro = _mapper.Map<Livro>(livroDTO);
            var result = await _livroRepository.Update(livro, id);
            if(result == null) return NotFound();
            return NoContent();
        }

        [HttpDelete("id")]
        [Authorize]
        public async Task<ActionResult<Livro>> Remove(int id) {
            var result = await _livroRepository.Remove(id);
            if(result == null) return NotFound();
            return NoContent();
        }

    }
}
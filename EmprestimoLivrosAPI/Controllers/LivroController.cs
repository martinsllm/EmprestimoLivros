using AutoMapper;
using EmprestimoLivrosAPI.DTOs;
using EmprestimoLivrosAPI.Models;
using EmprestimoLivrosAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoLivrosAPI.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase {

        private readonly IEntityRepository<Livro> _livroRepository;

        private readonly IMapper _mapper;

        public LivroController(IEntityRepository<Livro> livroRepository, IMapper mapper) {
            _livroRepository = livroRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Livro>>> Get() {
            var livros = await _livroRepository.Get();
            var livrosDTO = _mapper.Map<List<LivroDTO>>(livros);
            return Ok(livrosDTO);
        }

        [HttpGet("id")]
        public async Task<ActionResult<List<Livro>>> GetById(int id) {
            var livro = await _livroRepository.GetById(id);
            if(livro == null) return NotFound();
            var livroDTO = _mapper.Map<LivroDTO>(livro);
            return Ok(livroDTO);
        }

        [HttpPost]
        public async Task<ActionResult<Livro>> Create([FromBody] LivroDTO livroDTO) {
            var livro = _mapper.Map<Livro>(livroDTO);
            var result = await _livroRepository.Create(livro);
            if(result == null) return BadRequest();
            return Created();
        }

        [HttpPut("id")]
        public async Task<ActionResult<Livro>> Update([FromBody] LivroDTO livroDTO, int id) {
            var livro = _mapper.Map<Livro>(livroDTO);
            var result = await _livroRepository.Update(livro, id);
            if(result == null) return NotFound();
            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<ActionResult<Livro>> Remove(int id) {
            var result = await _livroRepository.Remove(id);
            if(result == null) return NotFound();
            return NoContent();
        }

    }
}
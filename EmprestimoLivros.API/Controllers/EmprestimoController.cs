using AutoMapper;
using EmprestimoLivros.Application.DTOs;
using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoLivros.API.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class EmprestimoController : ControllerBase {

        private readonly IEmprestimoRepository _emprestimoRepository;

        private readonly IMapper _mapper;

        public EmprestimoController(IEmprestimoRepository emprestimoRepository, IMapper mapper) {
            _emprestimoRepository = emprestimoRepository;
            _mapper = mapper;
        }

        [HttpGet("cliente/id")]
        [Authorize]
        public async Task<ActionResult<Emprestimo>> GetByCliente(int id) {
            var emprestimos = await _emprestimoRepository.GetByCliente(id);
            var emprestimosDTO = _mapper.Map<List<EmprestimoDTO>>(emprestimos);
            return Ok(emprestimosDTO);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Emprestimo>> Create([FromBody] EmprestimoPostDTO emprestimoDTO) {
            var emprestimo = _mapper.Map<Emprestimo>(emprestimoDTO);
            var result = await _emprestimoRepository.Create(emprestimo);
            if(result == null) return BadRequest();
            return Created();
        }

        [HttpDelete("id")]
        [Authorize]
        public async Task<ActionResult<Emprestimo>> Remove(int id) {
            var result = await _emprestimoRepository.Remove(id);
            if(result == null) return NotFound();
            return NoContent();
        }

    }
}
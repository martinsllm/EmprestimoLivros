using EmprestimoLivros.Application.DTOs;
using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoLivros.API.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class EmprestimoController : ControllerBase {

        private readonly IEmprestimoService _emprestimoService;

        public EmprestimoController(IEmprestimoService emprestimoService) {
            _emprestimoService = emprestimoService;
        }

        [HttpGet("cliente/id")]
        [Authorize]
        public async Task<ActionResult<Emprestimo>> GetByCliente(int id) {
            var emprestimos = await _emprestimoService.GetByCliente(id);
            return Ok(emprestimos);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Emprestimo>> Create([FromBody] EmprestimoPostDTO emprestimoDTO) {
            var verificaSeLivroEstaEmprestado = await _emprestimoService.GetByLivro(emprestimoDTO.LivroId);
            if(verificaSeLivroEstaEmprestado != null) return Conflict("Este livro já foi emprestado!");

            var emprestimo = await _emprestimoService.Create(emprestimoDTO);
            if(emprestimo == null) return BadRequest("Ocorreu um erro ao realizar o empréstimo!");
            return Created();
        }

        [HttpDelete("id")]
        [Authorize]
        public async Task<ActionResult<Emprestimo>> Remove(int id) {
            var emprestimo = await _emprestimoService.Remove(id);
            if(emprestimo == null) return BadRequest("Ocorreu um erro ao excluir o empréstimo!");
            return NoContent();
        }

    }
}
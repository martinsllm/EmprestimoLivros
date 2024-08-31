using EmprestimoLivros.Application.DTOs;
using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoLivros.API.Controllers {
    
    [ApiController] 
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase {

        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService) {
            _clienteService = clienteService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<Cliente>>> Get() {
            var clientes = await _clienteService.Get();
            return Ok(clientes);
        }

        [HttpGet("id")]
        [Authorize]
        public async Task<ActionResult<Cliente>> GetById(int id) {
            var cliente = await _clienteService.GetById(id);
            if(cliente == null) return NotFound("Cliente não encontrado!");
            return Ok(cliente);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Cliente>> Create([FromBody] ClienteDTO clienteDTO) {
            var verificaSeEmailExiste = await _clienteService.GetByEmail(clienteDTO.Email);
            if(verificaSeEmailExiste != null) return Conflict("Já existe um cliente cadastrado com este e-mail!");

            var cliente = await _clienteService.Create(clienteDTO);
            if(cliente == null) return BadRequest("Ocorreu um erro ao cadastrar o cliente!");
            return Created();
        }

        [HttpPut("id")]
        [Authorize]
        public async Task<ActionResult<Cliente>> Update([FromBody] ClienteDTO clienteDTO, int id) {
            var cliente = await _clienteService.Update(clienteDTO, id);
            if(cliente == null) return BadRequest("Ocorreu um erro ao alterar os dados do cliente!");
            return NoContent();
        }

        [HttpDelete("id")]
        [Authorize]
        public async Task<ActionResult<Cliente>> Remove(int id) {
            var cliente = await _clienteService.Remove(id);
            if(cliente == null) return BadRequest("Ocorreu um erro ao excluir o cliente!");
            return Created();
        }
    }
}
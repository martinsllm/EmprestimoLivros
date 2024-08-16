using EmprestimoLivrosAPI.Models;
using EmprestimoLivrosAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoLivrosAPI.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase {

        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clientRepository) {
            _clienteRepository = clientRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> Get() {
            var clientes = await _clienteRepository.Get();
            return Ok(clientes);
        }

        [HttpGet("id")]
        public async Task<ActionResult<Cliente>> GetById(int id) {
            var cliente = await _clienteRepository.GetById(id);
            if(cliente == null) return NotFound();
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> Create([FromBody] Cliente clienteDTO) {
            var result = await _clienteRepository.Create(clienteDTO);
            if(result == null) return BadRequest();
            return Created();
        }

    }
}
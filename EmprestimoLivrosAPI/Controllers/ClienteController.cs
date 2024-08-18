using AutoMapper;
using EmprestimoLivrosAPI.DTOs;
using EmprestimoLivrosAPI.Models;
using EmprestimoLivrosAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoLivrosAPI.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase {

        private readonly IEntityRepository<Cliente> _clienteRepository;

        private readonly IMapper _mapper;

        public ClienteController(IEntityRepository<Cliente> clientRepository, IMapper mapper) {
            _clienteRepository = clientRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<Cliente>>> Get() {
            var clientes = await _clienteRepository.Get();
            var clientesDTO = _mapper.Map<List<ClienteDTO>>(clientes);
            return Ok(clientesDTO);
        }

        [HttpGet("id")]
        [Authorize]
        public async Task<ActionResult<Cliente>> GetById(int id) {
            var cliente = await _clienteRepository.GetById(id);
            if(cliente == null) return NotFound();
            var clienteDTO = _mapper.Map<ClienteDTO>(cliente);
            return Ok(clienteDTO);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Cliente>> Create([FromBody] ClienteDTO clienteDTO) {
            var cliente = _mapper.Map<Cliente>(clienteDTO);
            var result = await _clienteRepository.Create(cliente);
            if(result == null) return BadRequest();
            return Created();
        }

        [HttpPut("id")]
        [Authorize]
        public async Task<ActionResult<Cliente>> Update([FromBody] ClienteDTO clienteDTO, int id) {
            var cliente = _mapper.Map<Cliente>(clienteDTO);
            var result = await _clienteRepository.Update(cliente, id);
            if(result == null) return NotFound();
            return NoContent();
        }

        [HttpDelete("id")]
        [Authorize]
        public async Task<ActionResult<Cliente>> Remove(int id) {
            var result = await _clienteRepository.Remove(id);
            if(result == null) return NotFound();
            return Created();
        }
    }
}
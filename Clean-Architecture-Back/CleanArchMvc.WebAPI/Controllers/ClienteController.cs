using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteervice _Clienteervice;

        public ClienteController(IClienteervice Clienteervice)
        {
            _Clienteervice = Clienteervice;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> Get()
        {
            var Cliente = await _Clienteervice.GetCliente();
            if(Cliente == null)
            {
                return NotFound();
            }
            return Ok(Cliente);
        }
        [HttpGet("{id:int}", Name = "GetClienteId")]
        public async Task<ActionResult<ClienteDTO>> Get(int id)
        {
            var Cliente = await _Clienteervice.GetById(id);
            if (Cliente == null)
            {
                return NotFound("Cliente not found!");
            }
            return Ok(Cliente);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClienteDTO Cliente)
        {
            if (Cliente == null)
            {
                return BadRequest("Invalid Data");
            }
            await _Clienteervice.Add(Cliente);
            return new CreatedAtRouteResult("GetGategoryId", new { id = Cliente.Id }, Cliente); //Retorna 201
        }
        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] ClienteDTO Cliente)
        {
            if (id != Cliente.Id)
            {
                return BadRequest();
            }
            if (Cliente == null)
            {
                return BadRequest();
            }
            await _Clienteervice.Update(Cliente);
            return Ok(Cliente);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ClienteDTO>> Delete(int id)
        {
            var Cliente = await _Clienteervice.GetById(id);
            if (Cliente == null)
            {
                return NotFound();
            }
            await _Clienteervice.Remove(id);
            return Ok(Cliente);
        }
    }
}
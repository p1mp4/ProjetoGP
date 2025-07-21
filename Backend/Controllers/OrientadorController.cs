using Backend.DTO.Orientador;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Professor,Admin")]
    public class OrientadorController : ControllerBase
    {
        private readonly IOrientadorRepository _repository;

        public OrientadorController(IOrientadorRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrientadorDTO dto)
        {
            var novo = new Orientador
            {
                PropostaProjetoId = dto.PropostaProjetoId,
                UtilizadorId = dto.UtilizadorId,
                TipoOrientador = dto.TipoOrientador
            };

            var criado = await _repository.CreateAsync(novo);
            return Ok(criado);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lista = await _repository.GetAllAsync();
            return Ok(lista);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _repository.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}

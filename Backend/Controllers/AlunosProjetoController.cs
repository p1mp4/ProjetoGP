using Backend.DTO.AlunosProjeto;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Aluno")]
    public class AlunosProjetoController : ControllerBase
    {
        private readonly IAlunosProjetoRepository _repository;

        public AlunosProjetoController(IAlunosProjetoRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AlunosProjetoDTO dto)
        {
            var userId = int.Parse(User.FindFirstValue("id")!);
            if (dto.UtilizadorId != userId)
            {
                return Forbid();
            }

            var novo = new AlunosProjeto
            {
                CandidaturaId = dto.CandidaturaId,
                PropostaProjetoId = dto.PropostaProjetoId,
                UtilizadorId = dto.UtilizadorId,
                UtilizadorSecId = dto.UtilizadorSecId
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
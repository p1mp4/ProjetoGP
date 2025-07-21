using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Interfaces;
using Backend.DTO.Candidatura;
using Backend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace Backend.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
    public class CandidaturaController : ControllerBase
    {
        private readonly ICandidaturaRepository _repository;
        private readonly ProjetoGestaoContext _context;

        public CandidaturaController(ICandidaturaRepository repository, ProjetoGestaoContext context)
        {
            _repository = repository;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
                var candidaturas = await _repository.GetAllAsync();
                return Ok(candidaturas);   
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CandidaturaDTO>> GetById(int id)
        {
            var candidatura = await _repository.GetByIdAsync(id);
                if (candidatura == null) return NotFound();

                return Ok(candidatura);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CandidaturaDTO dto)
        {
            var utilizadorId = int.Parse(User.FindFirst("id")!.Value);
            var utilizadorSecId = int.Parse(User.FindFirst("id")!.Value);
            var candidatura = new Candidatura
            {
                OrdemPreferencia = dto.OrdemPreferencia,
                PropostaProjetoId = dto.PropostaProjetoId,
                UtilizadorId = utilizadorId,
                UtilizadorSecId = utilizadorSecId
            };

            var criada = await _repository.CreateAsync(candidatura);
            return CreatedAtAction(nameof(GetById), new { id = criada.CandidaturaId }, criada);
        }
        [Authorize]
        [HttpPut("{id}")]
public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CandidaturaCreateUpdateDTO dto)
{
    // Obter o UtilizadorId do JWT (aluno autenticado)
    var utilizadorId = int.Parse(User.FindFirst("id")!.Value);

    // Obter a candidatura atual da BD
    var existente = await _repository.GetByIdAsync(id);
    if (existente == null)
        return NotFound();

    // Verifica se o aluno autenticado é o dono da candidatura, para garantir segurança
    if (existente.UtilizadorId != utilizadorId)
        return Forbid("Não tem permissão para alterar esta candidatura.");

    // Atualizar dados com dto + utilizadorId autenticado
    existente.OrdemPreferencia = dto.OrdemPreferencia;
    existente.PropostaProjetoId = dto.PropostaProjetoId;
    existente.UtilizadorSecId = dto.UtilizadorSecId; // pode ser nulo, vem do dto

    // O UtilizadorId fica sempre o do JWT para garantir que não é alterado por request maliciosa
    existente.UtilizadorId = utilizadorId;

    await _context.SaveChangesAsync();

    // Retorna um DTO para a resposta (podes usar o mesmo dto ou um DTO de resposta se preferires)
    return Ok(new CandidaturaDTO
    {
        OrdemPreferencia = existente.OrdemPreferencia,
        PropostaProjetoId = existente.PropostaProjetoId,
        UtilizadorId = existente.UtilizadorId,
        UtilizadorSecId = existente.UtilizadorSecId
    });
}


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _repository.DeleteAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
    }

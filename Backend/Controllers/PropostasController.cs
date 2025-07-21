using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;
using Backend.Mappers;
using Backend.DTO.Proposta;
using Backend.Interfaces;
using Backend.Helpers;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropostasController : ControllerBase
    {
        private readonly ProjetoGestaoContext _context;

        private readonly IPropostaRepository _propostaRepo;
        public PropostasController(ProjetoGestaoContext context, IPropostaRepository propostaRepo)
        {
            _propostaRepo = propostaRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            var propostas = await _propostaRepo.GetAllAsync(query);

            var propostaDTO = propostas.Select(s => s.ToPropostaDTO());
            return Ok(propostas);

        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var proposta = await _context.PropostaProjeto.FindAsync(id);
            if (proposta == null)
                return NotFound();

            return Ok(proposta.ToPropostaDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePropostaRequestDTO propostaDTO)
        {
            var propostaModel = propostaDTO.ToPropostaFromCreateDTO();
            await _propostaRepo.CreateAsync(propostaModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = propostaModel.PropostaProjetoId }, propostaModel.ToPropostaDTO());
        }

        [HttpPut]
        [Route("{id}")]

        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePropostaRequestDTO updateDTO)
        {

            var propostaModel = await _propostaRepo.UpdateAsync(id, updateDTO);

            if (propostaModel == null)
                return NotFound();


            return Ok(propostaModel.ToPropostaDTO());

        }

        [HttpDelete]
        [Route("{id}")]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var propostaModel = await _context.PropostaProjeto.FirstOrDefaultAsync(x => x.PropostaProjetoId == id);
            if (propostaModel == null)
            {
                return NotFound();
            }

            _context.PropostaProjeto.Remove(propostaModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [Authorize]
        [HttpPost("{id}/like")]
        public async Task<IActionResult> LikeProposta(int id)
        {
            var utilizadorId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new InvalidOperationException("Claim missing"));
            var proposta = await _context.PropostaProjeto.FindAsync(id);
            var utilizador = await _context.Utilizador.FindAsync(utilizadorId);

            if (proposta == null || utilizador == null)
                return NotFound();

            bool jaDeuLike = await _context.LikeProposta.AnyAsync(x => x.UtilizadorId == utilizadorId && x.PropostaProjetoId == id);
            if (jaDeuLike)
                return BadRequest("Utilizador já deu like nesta proposta.");

            var like = new LikeProposta
            {
                UtilizadorId = utilizadorId,
                PropostaProjetoId = id
            };

            _context.LikeProposta.Add(like);
            await _context.SaveChangesAsync();

            return Ok("Like registado com sucesso.");
        }
        [HttpGet("{id}/likes")]
        public async Task<IActionResult> ContarLikes(int id)
        {
            var count = await _context.LikeProposta.CountAsync(x => x.PropostaProjetoId == id);
            return Ok(count);
        }
        
        [Authorize]
        [HttpDelete("{id}/likes")]
        public async Task<IActionResult> RemoverLike(int id)
        {
            var utilizadorId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new InvalidOperationException("Claim missing"));
        var like = await _context.LikeProposta
        .FirstOrDefaultAsync(x => x.PropostaProjetoId == id && x.UtilizadorId == utilizadorId);

        if (like == null)
        return NotFound("Like não encontrado.");

        _context.LikeProposta.Remove(like);
        await _context.SaveChangesAsync();

        return Ok("Like removido com sucesso.");
        }



}
}
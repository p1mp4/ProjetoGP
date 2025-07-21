using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Backend.DTO.SubmissaoProjeto;
using Backend.Data;
using Microsoft.AspNetCore.Authorization;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubmissaoProjetoController : ControllerBase
    {
        private readonly ISubmissaoProjetoRepository _repository;

        private readonly ProjetoGestaoContext _context;
       

        public SubmissaoProjetoController(ISubmissaoProjetoRepository repository, ProjetoGestaoContext context)
        {
            _repository = repository;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var submissões = await _repository.GetAllAsync();
            return Ok(submissões);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var submissao = await _repository.GetByIdAsync(id);
            if (submissao == null) return NotFound();
            return Ok(submissao);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SubmissaoProjetoDTO dto)
        {
            var utilizadorId = int.Parse(User.FindFirst("id")!.Value);
            var submissao = new SubmissaoProjeto
        {
        PropostaId = dto.PropostaId,
        UtilizadorId = utilizadorId,
        DataUpload = DateTime.Now
        };

        var novaSubmissao = await _repository.CreateAsync(submissao);
        return CreatedAtAction(nameof(GetById), new { id = novaSubmissao.SubmissaoProjetoId }, novaSubmissao);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var apagado = await _repository.DeleteAsync(id);
            if (!apagado) return NotFound();
            return NoContent();
        }
    }
}

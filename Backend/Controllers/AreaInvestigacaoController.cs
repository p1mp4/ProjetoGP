    using Microsoft.AspNetCore.Mvc;
    using Backend.DTO.AreaInvestigacaoDTO;
    using Backend.Models;
    using Backend.Interfaces;
    using Backend.Data;

    namespace Backend.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class AreaInvestigacaoController : ControllerBase
        {
            private readonly IAreaInvestigacaoRepository _repository;
            private readonly ProjetoGestaoContext _context;

            public AreaInvestigacaoController(IAreaInvestigacaoRepository repository, ProjetoGestaoContext context)
            {
                _context = context;
                _repository = repository;
            }
          

            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var areas = await _repository.GetAllAsync();
                return Ok(areas);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var area = await _repository.GetByIdAsync(id);
                if (area == null) return NotFound();

                return Ok(area);
            }

            [HttpPost]
            public async Task<IActionResult> Create([FromBody] AreaInvestigacaoDTO novaArea)
            {
                var entidade = new AreaInvestigacao
                {
                    Nome = novaArea.Nome,
                    Descricao = novaArea.Descricao
                };

                var criada = await _repository.CreateAsync(entidade);
                return CreatedAtAction(nameof(GetById), new { id = criada.AreaInvestigacaoId }, criada);
            }

            [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] AreaInvestigacaoDTO areaDTO)
        {
            var existente = await _repository.GetByIdAsync(id);
            if (existente == null)
        return NotFound();

            // Atualizar os dados
            existente.Nome = areaDTO.Nome;
            existente.Descricao = areaDTO.Descricao;

            await _context.SaveChangesAsync();

            return Ok(new AreaInvestigacaoDTO
            {
        Nome = existente.Nome,
        Descricao = existente.Descricao
        });
        }


            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                var sucesso = await _repository.DeleteAsync(id);
                if (!sucesso) return NotFound();

                return NoContent();
            }
        }
    }

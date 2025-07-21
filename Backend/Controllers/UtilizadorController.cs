using Microsoft.AspNetCore.Mvc;
using Backend.DTO.Utilizador;
using Backend.Models;
using Backend.Interfaces;
using Backend.Data;
using Backend.Repository;
using Microsoft.AspNetCore.Authorization;

namespace Backend.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class UtilizadorController : ControllerBase
        {
            private readonly IUtilizadorRepository _repository;
            private readonly ProjetoGestaoContext _context;

            public UtilizadorController(IUtilizadorRepository repository, ProjetoGestaoContext context)
            {
                _context = context;
                _repository = repository;
            }
          

            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var users = await _repository.GetAllAsync();
                return Ok(users);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var user = await _repository.GetByIdAsync(id);
                if (user == null) return NotFound();

                return Ok(user);
            }

            [Authorize]
            [HttpPost]
            public async Task<IActionResult> Create([FromBody] UtilizadorDTO novaUser)
            {
                var utilizadorId = int.Parse(User.FindFirst("id")!.Value);
                var entidade = new Utilizador
                {
                    Nome = novaUser.Nome,
                    Email = novaUser.Email,
                    GrupoUtilizadorId = novaUser.GrupoUtilizadorId
                };

                var criada = await _repository.CreateAsync(entidade);
                return CreatedAtAction(nameof(GetById), new { id = criada.UtilizadorId }, criada);
            }

            [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UtilizadorDTO userDTO)
        {
            var existente = await _repository.GetByIdAsync(id);
            if (existente == null)
        return NotFound();

            // Atualizar os dados
            existente.Nome = userDTO.Nome;
            existente.Email = userDTO.Email;
            existente.GrupoUtilizadorId = userDTO.GrupoUtilizadorId;

            await _context.SaveChangesAsync();

            return Ok(new UtilizadorDTO
            {
                    Nome = existente.Nome,
                    Email = existente.Email,
                    GrupoUtilizadorId = existente.GrupoUtilizadorId
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

    
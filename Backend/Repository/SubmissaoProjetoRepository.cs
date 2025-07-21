using Backend.Data;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
    
namespace Backend.Repository
{
    public class SubmissaoProjetoRepository : ISubmissaoProjetoRepository
    {
        private readonly ProjetoGestaoContext _context;

        public SubmissaoProjetoRepository(ProjetoGestaoContext context)
        {
            _context = context;
        }

        public async Task<List<SubmissaoProjeto>> GetAllAsync()
        {
            return await _context.SubmissoesProjeto.ToListAsync();
        }

        public async Task<SubmissaoProjeto?> GetByIdAsync(int id)
        {
            return await _context.SubmissoesProjeto.FindAsync(id);
        }

        public async Task<SubmissaoProjeto> CreateAsync(SubmissaoProjeto submissao)
        {
            await _context.SubmissoesProjeto.AddAsync(submissao);
            await _context.SaveChangesAsync();
            return submissao;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existente = await _context.SubmissoesProjeto.FindAsync(id);
            if (existente == null) return false;

            _context.SubmissoesProjeto.Remove(existente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

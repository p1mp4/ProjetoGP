using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Interfaces;

namespace Backend.Repository
{
    public class AlunosProjetoRepository : IAlunosProjetoRepository
    {
        private readonly ProjetoGestaoContext _context;

        public AlunosProjetoRepository(ProjetoGestaoContext context)
        {
            _context = context;
        }

        public async Task<AlunosProjeto> CreateAsync(AlunosProjeto entidade)
        {
            _context.AlunosProjeto.Add(entidade);
            await _context.SaveChangesAsync();
            return entidade;
        }

        public async Task<IEnumerable<AlunosProjeto>> GetAllAsync()
        {
            return await _context.AlunosProjeto.ToListAsync();
        }

        public async Task<AlunosProjeto?> GetByIdAsync(int id)
        {
            return await _context.AlunosProjeto.FindAsync(id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entidade = await _context.AlunosProjeto.FindAsync(id);
            if (entidade == null) return false;

            _context.AlunosProjeto.Remove(entidade);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
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
    public class OrientadorRepository : IOrientadorRepository
    {
        private readonly ProjetoGestaoContext _context;

        public OrientadorRepository(ProjetoGestaoContext context)
        {
            _context = context;
        }

        public async Task<Orientador> CreateAsync(Orientador entidade)
        {
            _context.Orientador.Add(entidade);
            await _context.SaveChangesAsync();
            return entidade;
        }

        public async Task<IEnumerable<Orientador>> GetAllAsync()
        {
            return await _context.Orientador.ToListAsync();
        }

        public async Task<Orientador?> GetByIdAsync(int id)
        {
            return await _context.Orientador.FindAsync(id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entidade = await _context.Orientador.FindAsync(id);
            if (entidade == null) return false;

            _context.Orientador.Remove(entidade);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
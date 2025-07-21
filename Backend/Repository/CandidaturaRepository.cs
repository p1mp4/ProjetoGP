using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.DTO.Candidatura;
using Backend.Interfaces;
using Microsoft.EntityFrameworkCore;
using Backend.Data;

namespace Backend.Repository
{
    public class CandidaturaRepository : ICandidaturaRepository
    {
        private readonly ProjetoGestaoContext _context;

        public CandidaturaRepository(ProjetoGestaoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Candidatura>> GetAllAsync()
        {
            return await _context.Candidatura.ToListAsync();
        }

        public async Task<Candidatura?> GetByIdAsync(int id)
        {
            return await _context.Candidatura.FindAsync(id);
        }

        public async Task<Candidatura> CreateAsync(Candidatura candidatura)
        {
            _context.Candidatura.Add(candidatura);
            await _context.SaveChangesAsync();
            return candidatura;
        }

        public async Task<Candidatura?> UpdateAsync(Candidatura candidatura)
        {
            var existing = await _context.Candidatura.FindAsync(candidatura.CandidaturaId);
            if (existing == null) return null;

            _context.Entry(existing).CurrentValues.SetValues(candidatura);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var candidatura = await _context.Candidatura.FindAsync(id);
            if (candidatura == null) return false;

            _context.Candidatura.Remove(candidatura);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
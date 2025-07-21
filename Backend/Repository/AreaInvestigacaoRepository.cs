using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.DTO.AreaInvestigacaoDTO;
using Backend.Interfaces;
using Backend.Models;
using Backend.Repository;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class AreaInvestigacaoRepository : IAreaInvestigacaoRepository
    {

    private readonly ProjetoGestaoContext _context;

    public AreaInvestigacaoRepository(ProjetoGestaoContext context)
    {
        _context = context;
    }
    
    public async Task<List<AreaInvestigacao>> GetAllAsync()
    {
       return await _context.AreaInvestigacao.ToListAsync();
    }

    public async Task<AreaInvestigacao?> GetByIdAsync(int id)
    {
     return await _context.AreaInvestigacao.FindAsync(id);
    }

    public async Task<AreaInvestigacao> CreateAsync(AreaInvestigacao area)
        {
            await _context.AreaInvestigacao.AddAsync(area);
            await _context.SaveChangesAsync();
            return area;
        }

        public async Task<bool> UpdateAsync(int id, AreaInvestigacao area)
        {
        var existente = await _context.AreaInvestigacao.FindAsync(id);
            if (existente == null) return false;

            existente.Nome = area.Nome;
            await _context.SaveChangesAsync();
        return true;
        }

        public async Task<bool> DeleteAsync(int id)
    {
   var existente = await _context.AreaInvestigacao.FindAsync(id);
            if (existente == null) return false;

            _context.AreaInvestigacao.Remove(existente);
            await _context.SaveChangesAsync();
            return true;
    }
}
}

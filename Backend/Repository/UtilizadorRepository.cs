using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Interfaces;
using Microsoft.EntityFrameworkCore;
using Backend.Data;


namespace Backend.Repository
{
    public class UtilizadorRepository : IUtilizadorRepository
    {
        private readonly ProjetoGestaoContext _context;

    public UtilizadorRepository(ProjetoGestaoContext context)
    {
        _context = context;
    }
    
    public async Task<List<Utilizador>> GetAllAsync()
    {
       return await _context.Utilizador.ToListAsync();
    }

    public async Task<Utilizador?> GetByIdAsync(int id)
    {
     return await _context.Utilizador.FindAsync(id);
    }

    public async Task<Utilizador> CreateAsync(Utilizador user)
        {
            await _context.Utilizador.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> UpdateAsync(int id, Utilizador user)
        {
        var existente = await _context.Utilizador.FindAsync(id);
            if (existente == null) return false;

            existente.Nome = user.Nome;
            await _context.SaveChangesAsync();
        return true;
        }

        public async Task<bool> DeleteAsync(int id)
    {
   var existente = await _context.Utilizador.FindAsync(id);
            if (existente == null) return false;

            _context.Utilizador.Remove(existente);
            await _context.SaveChangesAsync();
            return true;
    }
    }
}
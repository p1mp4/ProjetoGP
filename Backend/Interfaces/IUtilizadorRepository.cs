using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Interfaces
{
    public interface IUtilizadorRepository
    {
        Task<List<Utilizador>> GetAllAsync();
        Task<Utilizador?> GetByIdAsync(int id);
        Task<Utilizador> CreateAsync(Utilizador user);
        Task<bool> UpdateAsync(int id, Utilizador user);
        Task<bool> DeleteAsync(int id);
    }
}
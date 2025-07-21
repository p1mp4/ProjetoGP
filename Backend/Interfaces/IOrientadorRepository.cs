using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Interfaces
{
    public interface IOrientadorRepository
    {
        Task<IEnumerable<Orientador>> GetAllAsync();
        Task<Orientador?> GetByIdAsync(int id);
        Task<Orientador> CreateAsync(Orientador entidade);
        Task<bool> DeleteAsync(int id);
    }
}
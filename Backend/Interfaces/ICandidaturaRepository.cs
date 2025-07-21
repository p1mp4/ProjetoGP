using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Interfaces
{
    public interface ICandidaturaRepository
    {
        Task<IEnumerable<Candidatura>> GetAllAsync();
        Task<Candidatura?> GetByIdAsync(int id);
        Task<Candidatura> CreateAsync(Candidatura candidatura);
        Task<Candidatura?> UpdateAsync(Candidatura candidatura);
        Task<bool> DeleteAsync(int id);
    }
}
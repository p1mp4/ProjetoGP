using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Interfaces
{
    public interface IAlunosProjetoRepository
    {
        Task<IEnumerable<AlunosProjeto>> GetAllAsync();
        Task<AlunosProjeto?> GetByIdAsync(int id);
        Task<AlunosProjeto> CreateAsync(AlunosProjeto entidade);
        Task<bool> DeleteAsync(int id);
    }
}
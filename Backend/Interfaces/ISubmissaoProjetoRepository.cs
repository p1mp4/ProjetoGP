using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Interfaces
{
    public interface ISubmissaoProjetoRepository
    {
        Task<List<SubmissaoProjeto>> GetAllAsync();
        Task<SubmissaoProjeto?> GetByIdAsync(int id);
        Task<SubmissaoProjeto> CreateAsync(SubmissaoProjeto submissao);
        Task<bool> DeleteAsync(int id);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DTO.Proposta;
using Backend.Helpers;
using Backend.Models;

namespace Backend.Interfaces
{
    public interface IPropostaRepository
    {
        Task<List<PropostaProjeto>> GetAllAsync(QueryObject query);

        Task<PropostaProjeto?> GetByIdAsync(int id);

        Task<PropostaProjeto> CreateAsync(PropostaProjeto propostaModel);

        Task<PropostaProjeto?> UpdateAsync(int id, UpdatePropostaRequestDTO propostaDTO);

        Task<PropostaProjeto?> DeleteAsync(int id);
    }
}
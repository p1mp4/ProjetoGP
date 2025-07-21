using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DTO.AreaInvestigacaoDTO;
using Backend.Models;

namespace Backend.Interfaces
{
    public interface IAreaInvestigacaoRepository
    {
        Task<List<AreaInvestigacao>> GetAllAsync();
        Task<AreaInvestigacao?> GetByIdAsync(int id);
        Task<AreaInvestigacao> CreateAsync(AreaInvestigacao area);
        Task<bool> UpdateAsync(int id, AreaInvestigacao area);
        Task<bool> DeleteAsync(int id);
    }
}
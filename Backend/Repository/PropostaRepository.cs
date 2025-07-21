using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.DTO.Proposta;
using Backend.Helpers;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class PropostaRepository : IPropostaRepository
    {
        private readonly ProjetoGestaoContext _context;
        public PropostaRepository(ProjetoGestaoContext context)
        {
            _context = context;
        }

        public async Task<PropostaProjeto> CreateAsync(PropostaProjeto propostaModel)
        {
            await _context.PropostaProjeto.AddAsync(propostaModel);
            await _context.SaveChangesAsync();
            return propostaModel;
        }

        public async Task<PropostaProjeto?> DeleteAsync(int id)
        {
            var propostaModel = await _context.PropostaProjeto.FirstOrDefaultAsync(x => x.PropostaProjetoId == id);

            if (propostaModel == null)
                return null;

            _context.PropostaProjeto.Remove(propostaModel);
            await _context.SaveChangesAsync();
            return propostaModel;
        }

        public async Task<List<PropostaProjeto>> GetAllAsync(QueryObject query)
        {
            var projetos = _context.PropostaProjeto.AsQueryable();

            if (!string.IsNullOrEmpty(query.Titulo))
            {
                projetos = projetos.Where(x => x.Titulo.Contains(query.Titulo));
            }
            if (!string.IsNullOrEmpty(query.CentroInvestigacao))
            {
                projetos = projetos.Where(x => x.Titulo.Contains(query.CentroInvestigacao));
            }
            if (query.AreaInvestigacaoId != null)
            {
                projetos = projetos.Where(x => x.AreaInvestigacaoId == query.AreaInvestigacaoId);
            }
            if (!string.IsNullOrEmpty(query.Dependencias))
            {
                projetos = projetos.Where(x => x.Dependencias.Contains(query.Dependencias));
            }

            if (!string.IsNullOrEmpty(query.SortBy))
            {
                if (query.SortBy.Equals("Titulo", StringComparison.OrdinalIgnoreCase))
                {
                    projetos = query.IsDescending ? projetos.OrderByDescending(x => x.Titulo) : projetos.OrderBy(x => x.Titulo);
                }
                else if (query.SortBy.Equals("CentroInvestigacao", StringComparison.OrdinalIgnoreCase))
                {
                    projetos = query.IsDescending ? projetos.OrderByDescending(x => x.CentroInvestigacao) : projetos.OrderBy(x => x.CentroInvestigacao);
                }
                else if (query.SortBy.Equals("AreaInvestigacaoId", StringComparison.OrdinalIgnoreCase))
                {
                    projetos = query.IsDescending ? projetos.OrderByDescending(x => x.AreaInvestigacaoId) : projetos.OrderBy(x => x.AreaInvestigacaoId);
                }
                else if (query.SortBy.Equals("Dependencias", StringComparison.OrdinalIgnoreCase))
                {
                    projetos = query.IsDescending ? projetos.OrderByDescending(x => x.Dependencias) : projetos.OrderBy(x => x.Dependencias);
                }

            }
            var skipNumber = (query.PageNumber - 1) * query.PageSize;
            return await projetos.Skip(skipNumber).Take(query.PageSize).ToListAsync();
            
        
        }

        public async Task<PropostaProjeto?> GetByIdAsync(int id)
        {
            return await _context.PropostaProjeto.FindAsync(id);
        }

        public async Task<PropostaProjeto?> UpdateAsync(int id, UpdatePropostaRequestDTO propostaDTO)
        {
            var ExisteProposta = await _context.PropostaProjeto.FirstOrDefaultAsync(x => x.PropostaProjetoId == id);

            if (ExisteProposta == null)
                return null;

        ExisteProposta.Caminho = propostaDTO.Caminho;
        ExisteProposta.Titulo = propostaDTO.Titulo;
        ExisteProposta.AreaInvestigacaoId = propostaDTO.AreaInvestigacaoId;
        ExisteProposta.CentroInvestigacao = propostaDTO.CentroInvestigacao;
        ExisteProposta.Dependencias = propostaDTO.Dependencias;
        ExisteProposta.Apresentacao = propostaDTO.Apresentacao;
        ExisteProposta.Objetivos = propostaDTO.Objetivos;
        ExisteProposta.Estado = propostaDTO.Estado;
        ExisteProposta.Editavel = propostaDTO.Editavel;
        ExisteProposta.Visivel = propostaDTO.Visivel;


        await _context.SaveChangesAsync();
            return ExisteProposta;
        }
    }
}
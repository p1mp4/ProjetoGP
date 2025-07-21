using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DTO.Proposta;
using Backend.Models;

namespace Backend.Mappers
{
    public static class PropostaMappers
    {
        public static PropostaDTO ToPropostaDTO(this PropostaProjeto PropostaModel)

        {
            return new PropostaDTO
            {
                PropostaProjetoId = PropostaModel.PropostaProjetoId,
                Caminho = PropostaModel.Caminho,
                Titulo = PropostaModel.Titulo,
                AreaInvestigacaoId = PropostaModel.AreaInvestigacaoId,
                CentroInvestigacao = PropostaModel.CentroInvestigacao,
                Dependencias = PropostaModel.Dependencias,
                Apresentacao = PropostaModel.Apresentacao,
                Objetivos = PropostaModel.Objetivos,
                Estado = PropostaModel.Estado,
                Editavel = PropostaModel.Editavel,
                Visivel = PropostaModel.Visivel,
                AnoLetivo = PropostaModel.AnoLetivo
            };
        }

        public static PropostaProjeto ToPropostaFromCreateDTO(this CreatePropostaRequestDTO propostaDTO)
        {
            return new PropostaProjeto
            {
                Caminho = propostaDTO.Caminho,
                Titulo = propostaDTO.Titulo,
                AreaInvestigacaoId = propostaDTO.AreaInvestigacaoId,
                CentroInvestigacao = propostaDTO.CentroInvestigacao,
                Dependencias = propostaDTO.Dependencias,
                Apresentacao = propostaDTO.Apresentacao,
                Objetivos = propostaDTO.Objetivos,
                Estado = propostaDTO.Estado,
                Editavel = propostaDTO.Editavel,
                Visivel = propostaDTO.Visivel,
                AnoLetivo = propostaDTO.AnoLetivo
            };
        }
       
}
}
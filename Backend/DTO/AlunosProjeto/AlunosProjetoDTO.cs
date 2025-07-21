using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DTO.AlunosProjeto
{
    public class AlunosProjetoDTO
    {
        public int CandidaturaId { get; set; }
        public int PropostaProjetoId { get; set; }
        public int UtilizadorId { get; set; }
        public int? UtilizadorSecId { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DTO.Candidatura
{
    public class CandidaturaDTO
    {
        public int OrdemPreferencia { get; set; }
        public int PropostaProjetoId { get; set; }
        public int UtilizadorId { get; set; }
        public int? UtilizadorSecId { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DTO.Candidatura
{
    public class CandidaturaCreateUpdateDTO
    {
        public int OrdemPreferencia { get; set; }
        public int PropostaProjetoId { get; set; }
        public int? UtilizadorSecId { get; set; }
    }
}
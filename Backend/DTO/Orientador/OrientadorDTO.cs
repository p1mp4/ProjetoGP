using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DTO.Orientador
{
    public class OrientadorDTO
    {
        public int PropostaProjetoId { get; set; }
        public int UtilizadorId { get; set; }
        public string TipoOrientador { get; set; } = string.Empty;
    }
}
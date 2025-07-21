using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class LikeProposta
    {
         public int LikePropostaId { get; set; }

        public int UtilizadorId { get; set; }
        public Utilizador? Utilizador { get; set; }

        public int PropostaProjetoId { get; set; }
        public PropostaProjeto? PropostaProjeto { get; set; }

        public DateTime DataLike { get; set; } = DateTime.UtcNow;
    }
}
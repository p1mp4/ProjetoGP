using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.DTO.Utilizador
{
    public class UtilizadorDTO
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public int GrupoUtilizadorId { get; set; }

    }
}
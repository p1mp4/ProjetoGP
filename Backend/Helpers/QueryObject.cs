using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Helpers
{
    public class QueryObject
    {
        public string? Titulo { get; set; } = null;
        public int? AreaInvestigacaoId { get; set; } = null;
        public string? CentroInvestigacao { get; set; } = null;
        public string? Dependencias { get; set; } = null;

        public string? SortBy { get; set; } = null;

        public bool IsDescending { get; set; } = false;

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 20;
    }
}
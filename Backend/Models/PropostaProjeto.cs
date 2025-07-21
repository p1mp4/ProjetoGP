namespace Backend.Models{
    public class PropostaProjeto
    {
        public int PropostaProjetoId { get; set; }
        public string Caminho { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public int AreaInvestigacaoId { get; set; }

        public string CentroInvestigacao { get; set; } = string.Empty;

        public string Dependencias { get; set; } = string.Empty;
        public string Apresentacao { get; set; } = string.Empty;
        public string Objetivos { get; set; } = string.Empty;
        public bool Estado { get; set; } = false;
        public bool Editavel { get; set; } = false;
        public bool Visivel { get; set; } = false;
        public int AnoLetivo { get; set; }

    
}
}
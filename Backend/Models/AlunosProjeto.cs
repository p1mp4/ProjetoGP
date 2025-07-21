namespace Backend.Models{

    public class AlunosProjeto
    {
        public int AlunosProjetoId { get; set; }
        public int CandidaturaId { get; set; }
        public int PropostaProjetoId { get; set; }
        public int UtilizadorId { get; set; }
        public int? UtilizadorSecId { get; set; }
}
}
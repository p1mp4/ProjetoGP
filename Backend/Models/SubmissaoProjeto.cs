namespace Backend.Models{
public class SubmissaoProjeto
{
    public int SubmissaoProjetoId { get; set; }
    public DateTime DataUpload { get; set; }
    public int PropostaId { get; set; }
    public int UtilizadorId { get; set; }
}
}

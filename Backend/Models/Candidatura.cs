namespace Backend.Models{
public class Candidatura
{
    public int CandidaturaId { get; set; }
    public int OrdemPreferencia { get; set; }
    public string Estado { get; set; } = string.Empty;
    public DateTime DataSubmissao { get; set; }
    public int PropostaProjetoId { get; set; }
    public int UtilizadorId { get; set; }

    public int? UtilizadorSecId { get; set; }

}
}
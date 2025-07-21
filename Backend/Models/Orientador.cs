namespace Backend.Models{
public class Orientador
{
    public int OrientadorId { get; set; }
    public int PropostaProjetoId { get; set; }
    public int UtilizadorId { get; set; }
    public string TipoOrientador { get; set; } = string.Empty;
}
}
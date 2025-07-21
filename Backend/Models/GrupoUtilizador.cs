namespace Backend.Models {
public class GrupoUtilizador
{
    public int GrupoUtilizadorId { get; set; }
        public string Descricao { get; set; } = string.Empty;

        public ICollection<Utilizador> Utilizadores { get; set; } = new List<Utilizador>();
}
}
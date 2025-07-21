
namespace Backend.Models{
public class Utilizador
{
        public int UtilizadorId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PalavraPasseHash { get; set; } = string.Empty;
        public int GrupoUtilizadorId { get; set; }
}
}
using Microsoft.EntityFrameworkCore;
using Backend.Models;


namespace Backend.Data{
public class ProjetoGestaoContext : DbContext
{
      public ProjetoGestaoContext(DbContextOptions options) : base(options) { }

        public DbSet<PropostaProjeto> PropostaProjeto { get; set; }
        public DbSet<AreaInvestigacao> AreaInvestigacao { get; set; }
        public DbSet<Utilizador> Utilizador { get; set; }
        public DbSet<GrupoUtilizador> GrupoUtilizador { get; set; }
        public DbSet<Candidatura> Candidatura { get; set; }
        public DbSet<AlunosProjeto> AlunosProjeto { get; set; }
        public DbSet<SubmissaoProjeto> SubmissoesProjeto { get; set; }
        public DbSet<Orientador> Orientador { get; set; }
        public DbSet<LikeProposta> LikeProposta { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<LikeProposta>()
        .HasIndex(lp => new { lp.UtilizadorId, lp.PropostaProjetoId })
        .IsUnique();



        }
}
}
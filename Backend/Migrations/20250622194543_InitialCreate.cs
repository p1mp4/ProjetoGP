using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlunosProjeto",
                columns: table => new
                {
                    AlunosProjetoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidaturaId = table.Column<int>(type: "int", nullable: false),
                    PropostaProjetoId = table.Column<int>(type: "int", nullable: false),
                    UtilizadorId = table.Column<int>(type: "int", nullable: false),
                    UtilizadorSecId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosProjeto", x => x.AlunosProjetoId);
                });

            migrationBuilder.CreateTable(
                name: "AreaInvestigacao",
                columns: table => new
                {
                    AreaInvestigacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaInvestigacao", x => x.AreaInvestigacaoId);
                });

            migrationBuilder.CreateTable(
                name: "Candidatura",
                columns: table => new
                {
                    CandidaturaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdemPreferencia = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataSubmissao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PropostaProjetoId = table.Column<int>(type: "int", nullable: false),
                    UtilizadorId = table.Column<int>(type: "int", nullable: false),
                    UtilizadorSecId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidatura", x => x.CandidaturaId);
                });

            migrationBuilder.CreateTable(
                name: "GrupoUtilizador",
                columns: table => new
                {
                    GrupoUtilizadorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoUtilizador", x => x.GrupoUtilizadorId);
                });

            migrationBuilder.CreateTable(
                name: "Orientador",
                columns: table => new
                {
                    OrientadorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropostaProjetoId = table.Column<int>(type: "int", nullable: false),
                    UtilizadorId = table.Column<int>(type: "int", nullable: false),
                    TipoOrientador = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orientador", x => x.OrientadorId);
                });

            migrationBuilder.CreateTable(
                name: "PropostaProjeto",
                columns: table => new
                {
                    PropostaProjetoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Caminho = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreaInvestigacaoId = table.Column<int>(type: "int", nullable: false),
                    CentroInvestigacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dependencias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apresentacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Objetivos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    Editavel = table.Column<bool>(type: "bit", nullable: false),
                    Visivel = table.Column<bool>(type: "bit", nullable: false),
                    AnoLetivo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropostaProjeto", x => x.PropostaProjetoId);
                });

            migrationBuilder.CreateTable(
                name: "SubmissoesProjeto",
                columns: table => new
                {
                    SubmissaoProjetoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataUpload = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PropostaId = table.Column<int>(type: "int", nullable: false),
                    UtilizadorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubmissoesProjeto", x => x.SubmissaoProjetoId);
                });

            migrationBuilder.CreateTable(
                name: "Utilizador",
                columns: table => new
                {
                    UtilizadorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PalavraPasseHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GrupoUtilizadorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizador", x => x.UtilizadorId);
                    table.ForeignKey(
                        name: "FK_Utilizador_GrupoUtilizador_GrupoUtilizadorId",
                        column: x => x.GrupoUtilizadorId,
                        principalTable: "GrupoUtilizador",
                        principalColumn: "GrupoUtilizadorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LikeProposta",
                columns: table => new
                {
                    LikePropostaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtilizadorId = table.Column<int>(type: "int", nullable: false),
                    PropostaProjetoId = table.Column<int>(type: "int", nullable: false),
                    DataLike = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikeProposta", x => x.LikePropostaId);
                    table.ForeignKey(
                        name: "FK_LikeProposta_PropostaProjeto_PropostaProjetoId",
                        column: x => x.PropostaProjetoId,
                        principalTable: "PropostaProjeto",
                        principalColumn: "PropostaProjetoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LikeProposta_Utilizador_UtilizadorId",
                        column: x => x.UtilizadorId,
                        principalTable: "Utilizador",
                        principalColumn: "UtilizadorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LikeProposta_PropostaProjetoId",
                table: "LikeProposta",
                column: "PropostaProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_LikeProposta_UtilizadorId_PropostaProjetoId",
                table: "LikeProposta",
                columns: new[] { "UtilizadorId", "PropostaProjetoId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Utilizador_GrupoUtilizadorId",
                table: "Utilizador",
                column: "GrupoUtilizadorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunosProjeto");

            migrationBuilder.DropTable(
                name: "AreaInvestigacao");

            migrationBuilder.DropTable(
                name: "Candidatura");

            migrationBuilder.DropTable(
                name: "LikeProposta");

            migrationBuilder.DropTable(
                name: "Orientador");

            migrationBuilder.DropTable(
                name: "SubmissoesProjeto");

            migrationBuilder.DropTable(
                name: "PropostaProjeto");

            migrationBuilder.DropTable(
                name: "Utilizador");

            migrationBuilder.DropTable(
                name: "GrupoUtilizador");
        }
    }
}

using Bogus;
using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Backend.Data;

namespace Backend.Data
{
    public static class DbSeeder
    {
        public static void Seed(ProjetoGestaoContext context)
        {
            Console.WriteLine("Seed iniciado");
            if (context.Utilizador.Any())
            {
                Console.WriteLine("Dados já existem, seed cancelado");
                return;
            }

            Console.WriteLine("Inserindo dados...");
            // Faker para GrupoUtilizador
            var grupos = new List<GrupoUtilizador>
        {
            new GrupoUtilizador { Descricao = "Aluno" },
            new GrupoUtilizador { Descricao = "Professor" },
            new GrupoUtilizador { Descricao = "Admin" }
        };
            context.GrupoUtilizador.AddRange(grupos);
            context.SaveChanges();

            // Faker para Utilizador
            var utilizadorFaker = new Faker<Utilizador>("pt_PT")
                .RuleFor(u => u.Nome, f => f.Name.FullName())
                .RuleFor(u => u.Email, f => f.Internet.Email())
                .RuleFor(u => u.PalavraPasseHash, f => "hashedpassword") // idealmente usar hash real
                .RuleFor(u => u.GrupoUtilizadorId, f => f.PickRandom(grupos).GrupoUtilizadorId);

            var utilizadores = utilizadorFaker.Generate(30);
            context.Utilizador.AddRange(utilizadores);
            context.SaveChanges();

            // Faker para AreaInvestigacao
            var areaFaker = new Faker<AreaInvestigacao>("pt_PT")
                .RuleFor(a => a.Nome, f => f.Commerce.Department())
                .RuleFor(a => a.Descricao, f => f.Lorem.Sentence());

            var areas = areaFaker.Generate(5);
            context.AreaInvestigacao.AddRange(areas);
            context.SaveChanges();

            // Faker para PropostaProjeto
            var propostaFaker = new Faker<PropostaProjeto>("pt_PT")
                .RuleFor(p => p.Titulo, f => f.Company.CatchPhrase())
                .RuleFor(p => p.Caminho, f => f.System.FilePath())
                .RuleFor(p => p.AreaInvestigacaoId, f => f.PickRandom(areas).AreaInvestigacaoId)
                .RuleFor(p => p.CentroInvestigacao, f => f.Company.CompanyName())
                .RuleFor(p => p.Dependencias, f => f.Lorem.Word())
                .RuleFor(p => p.Apresentacao, f => f.Lorem.Paragraph())
                .RuleFor(p => p.Objetivos, f => f.Lorem.Paragraph())
                .RuleFor(p => p.Estado, f => f.Random.Bool())
                .RuleFor(p => p.Editavel, f => f.Random.Bool())
                .RuleFor(p => p.Visivel, f => f.Random.Bool())
                .RuleFor(p => p.AnoLetivo, f => f.Date.Past(3).Year);

            var propostas = propostaFaker.Generate(10);
            context.PropostaProjeto.AddRange(propostas);
            context.SaveChanges();

            // Faker para Candidatura
            var candidaturaFaker = new Faker<Candidatura>("pt_PT")
                .RuleFor(c => c.OrdemPreferencia, f => f.Random.Int(1, 3))
                .RuleFor(c => c.Estado, f => f.PickRandom(new[] { "Pendente", "Aceite", "Rejeitada" }))
                .RuleFor(c => c.DataSubmissao, f => f.Date.Recent(30))
                .RuleFor(c => c.PropostaProjetoId, f => f.PickRandom(propostas).PropostaProjetoId)
                .RuleFor(c => c.UtilizadorId, f => f.PickRandom(utilizadores).UtilizadorId)
                .RuleFor(c => c.UtilizadorSecId, f => null); // podes modificar conforme a regra

            var candidaturas = candidaturaFaker.Generate(20);
            context.Candidatura.AddRange(candidaturas);
            context.SaveChanges();

            // Faker para AlunosProjeto (liga alunos a candidaturas e propostas)
            var alunosProjetoFaker = new Faker<AlunosProjeto>("pt_PT")
                .RuleFor(ap => ap.CandidaturaId, f => f.PickRandom(candidaturas).CandidaturaId)
                .RuleFor(ap => ap.PropostaProjetoId, f => f.PickRandom(propostas).PropostaProjetoId)
                .RuleFor(ap => ap.UtilizadorId, f => f.PickRandom(utilizadores).UtilizadorId)
                .RuleFor(ap => ap.UtilizadorSecId, f => null);

            var alunosProjeto = alunosProjetoFaker.Generate(15);
            context.AlunosProjeto.AddRange(alunosProjeto);
            context.SaveChanges();

            // Faker para Orientador
            var orientadorFaker = new Faker<Orientador>("pt_PT")
                .RuleFor(o => o.PropostaProjetoId, f => f.PickRandom(propostas).PropostaProjetoId)
                .RuleFor(o => o.UtilizadorId, f => f.PickRandom(utilizadores).UtilizadorId)
                .RuleFor(o => o.TipoOrientador, f => f.PickRandom(new[] { "Interno", "Externo" }));

            var orientadores = orientadorFaker.Generate(10);
            context.Orientador.AddRange(orientadores);
            context.SaveChanges();

            // Faker para SubmissaoProjeto
            var submissaoFaker = new Faker<SubmissaoProjeto>("pt_PT")
                .RuleFor(s => s.DataUpload, f => f.Date.Recent(5))
                .RuleFor(s => s.PropostaId, f => f.PickRandom(propostas).PropostaProjetoId)
                .RuleFor(s => s.UtilizadorId, f => f.PickRandom(utilizadores).UtilizadorId);

            var submissaoProjetos = submissaoFaker.Generate(15);
            context.SubmissoesProjeto.AddRange(submissaoProjetos);
            context.SaveChanges();
        }
    }
}
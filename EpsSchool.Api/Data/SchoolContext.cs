using System;
using System.Collections.Generic;
using EpsSchool.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace EpsSchool.Api.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<AlunoCursoDisciplina> AlunosCursosDisciplinas { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<CursoDisciplina> CursosDisciplinas { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Professor> Professores { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AlunoCursoDisciplina>()
                .HasKey(AD => new { AD.AlunoId, AD.CursoDisciplinaId });

            builder.Entity<CursoDisciplina>()
                .HasKey(CD => new { CD.CursoId, CD.DisciplinaId });

            builder.Entity<Professor>()
                .HasData(new List<Professor>(){
                    new Professor(1, 1, "José", "Roberto"),
                    new Professor(2, 2, "Carlos", "Eduardo"),
                    new Professor(3, 3, "Manuel", "Nobre"),
                    new Professor(4, 4, "João", "Olavo"),
                    new Professor(5, 5, "Lucas", "Ribas"),
                });

            builder.Entity<Curso>()
                .HasData(new List<Curso>(){
                    new Curso(1, "Informatica"),
                    new Curso(2, "Manutenção de Micros"),
                    new Curso(3, "Redes de Computadores")
                });

            builder.Entity<Disciplina>()
                .HasData(new List<Disciplina>{
                    new Disciplina(1, "Matemática", 1),
                    new Disciplina(2, "Limpeza de Gabinete", 2),
                    new Disciplina(3, "Português", 3),
                    new Disciplina(4, "Arquitetura de Servidores", 4),
                    new Disciplina(5, "Programação", 5)
                });

            builder.Entity<Aluno>()
                .HasData(new List<Aluno>(){
                    new Aluno(1, 1, "Joana", "Alves", "33556699", DateTime.Parse("07/17/2010", new System.Globalization.CultureInfo("en-US"))),
                    new Aluno(2, 2, "Fernanda", "Silva", "33447789", DateTime.Parse("07/17/2010", new System.Globalization.CultureInfo("en-US"))),
                    new Aluno(3, 3, "Vanessa", "Lisboa", "99562341", DateTime.Parse("07/17/2010", new System.Globalization.CultureInfo("en-US"))),
                    new Aluno(4, 4, "Maria", "Madalena", "99452417", DateTime.Parse("07/17/2010", new System.Globalization.CultureInfo("en-US"))),
                    new Aluno(5, 5, "João", "Paulo", "98564712", DateTime.Parse("07/17/2010", new System.Globalization.CultureInfo("en-US"))),
                    new Aluno(6, 6, "Ananias", "Fernandes", "33589624", DateTime.Parse("07/17/2010", new System.Globalization.CultureInfo("en-US"))),
                    new Aluno(7, 7, "José", "Arimatéia", "98745122", DateTime.Parse("07/17/2010", new System.Globalization.CultureInfo("en-US")))
                });

            builder.Entity<CursoDisciplina>()
                .HasData(new List<CursoDisciplina>{
                    new CursoDisciplina(1, 1, 1),
                    new CursoDisciplina(2, 1, 3),
                    new CursoDisciplina(3, 1, 5),
                    new CursoDisciplina(4, 2, 2),
                    new CursoDisciplina(5, 2, 3),
                    new CursoDisciplina(6, 3, 1),
                    new CursoDisciplina(7, 3, 3),
                    new CursoDisciplina(8, 3, 4)
                });

            builder.Entity<AlunoCursoDisciplina>()
                .HasData(new List<AlunoCursoDisciplina>() {
                    new AlunoCursoDisciplina() {AlunoId = 1, CursoDisciplinaId = 1 },
                    new AlunoCursoDisciplina() {AlunoId = 1, CursoDisciplinaId = 2 },
                    new AlunoCursoDisciplina() {AlunoId = 1, CursoDisciplinaId = 3 },
                    new AlunoCursoDisciplina() {AlunoId = 2, CursoDisciplinaId = 1 },
                    new AlunoCursoDisciplina() {AlunoId = 2, CursoDisciplinaId = 2 },
                    new AlunoCursoDisciplina() {AlunoId = 2, CursoDisciplinaId = 3 },
                    new AlunoCursoDisciplina() {AlunoId = 3, CursoDisciplinaId = 4 },
                    new AlunoCursoDisciplina() {AlunoId = 3, CursoDisciplinaId = 5 },
                    new AlunoCursoDisciplina() {AlunoId = 4, CursoDisciplinaId = 4 },
                    new AlunoCursoDisciplina() {AlunoId = 4, CursoDisciplinaId = 5 },
                    new AlunoCursoDisciplina() {AlunoId = 5, CursoDisciplinaId = 4 },
                    new AlunoCursoDisciplina() {AlunoId = 5, CursoDisciplinaId = 5 },
                    new AlunoCursoDisciplina() {AlunoId = 6, CursoDisciplinaId = 5 },
                    new AlunoCursoDisciplina() {AlunoId = 6, CursoDisciplinaId = 6 },
                    new AlunoCursoDisciplina() {AlunoId = 6, CursoDisciplinaId = 7 },
                    new AlunoCursoDisciplina() {AlunoId = 7, CursoDisciplinaId = 5 },
                    new AlunoCursoDisciplina() {AlunoId = 7, CursoDisciplinaId = 6 },
                    new AlunoCursoDisciplina() {AlunoId = 7, CursoDisciplinaId = 7 }
                });
        }

    }
}
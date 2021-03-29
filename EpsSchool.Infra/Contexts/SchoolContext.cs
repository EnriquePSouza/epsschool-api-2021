using System;
using System.Collections.Generic;
using EpsSchool.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EpsSchool.infra.Contexts
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }
        public DbSet<Student> Alunos { get; set; }
        public DbSet<AlunoCursoDisciplina> AlunosCursosDisciplinas { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<CursoDisciplina> CursosDisciplinas { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Teacher> Professores { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AlunoCursoDisciplina>()
                .HasKey(AD => new { AD.StudentId, AD.CursoDisciplinaId });

            builder.Entity<Teacher>()
                .HasData(new List<Teacher>(){
                    new Teacher(1, 1, "José", "Roberto","44778899", DateTime.Parse("05/04/2000", new System.Globalization.CultureInfo("en-US"))),
                    new Teacher(2, 2, "Carlos", "Eduardo","33568941", DateTime.Parse("05/04/2000", new System.Globalization.CultureInfo("en-US"))),
                    new Teacher(3, 3, "Manuel", "Nobre","99587462", DateTime.Parse("05/04/2000", new System.Globalization.CultureInfo("en-US"))),
                    new Teacher(4, 4, "João", "Olavo","33506987", DateTime.Parse("05/04/2000", new System.Globalization.CultureInfo("en-US"))),
                    new Teacher(5, 5, "Lucas", "Ribas","33214896", DateTime.Parse("05/04/2000", new System.Globalization.CultureInfo("en-US")))
                });

            builder.Entity<Curso>()
                .HasData(new List<Curso>(){
                    new Curso(1, "Informatica"),
                    new Curso(2, "Manutenção de Micros"),
                    new Curso(3, "Redes de Computadores")
                });

            builder.Entity<Disciplina>()
                .HasData(new List<Disciplina>(){
                    new Disciplina(1, "Matemática", 1),
                    new Disciplina(2, "Limpeza de Gabinete", 2),
                    new Disciplina(3, "Português", 3),
                    new Disciplina(4, "Arquitetura de Servidores", 4),
                    new Disciplina(5, "Programação", 5)
                });

            builder.Entity<Student>()
                .HasData(new List<Student>(){
                    new Student(1, 1, "Joana", "Alves", "33556699", DateTime.Parse("07/17/2010", new System.Globalization.CultureInfo("en-US"))),
                    new Student(2, 2, "Fernanda", "Silva", "33447789", DateTime.Parse("07/17/2010", new System.Globalization.CultureInfo("en-US"))),
                    new Student(3, 3, "Vanessa", "Lisboa", "99562341", DateTime.Parse("07/17/2010", new System.Globalization.CultureInfo("en-US"))),
                    new Student(4, 4, "Maria", "Madalena", "99452417", DateTime.Parse("07/17/2010", new System.Globalization.CultureInfo("en-US"))),
                    new Student(5, 5, "João", "Paulo", "98564712", DateTime.Parse("07/17/2010", new System.Globalization.CultureInfo("en-US"))),
                    new Student(6, 6, "Ananias", "Fernandes", "33589624", DateTime.Parse("07/17/2010", new System.Globalization.CultureInfo("en-US"))),
                    new Student(7, 7, "José", "Arimatéia", "98745122", DateTime.Parse("07/17/2010", new System.Globalization.CultureInfo("en-US")))
                });

            builder.Entity<CursoDisciplina>()
                .HasData(new List<CursoDisciplina>() {
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
                    new AlunoCursoDisciplina(1,1),
                    new AlunoCursoDisciplina(1,2),
                    new AlunoCursoDisciplina(1,3),
                    new AlunoCursoDisciplina(2,1),
                    new AlunoCursoDisciplina(2,2),
                    new AlunoCursoDisciplina(2,3),
                    new AlunoCursoDisciplina(3,4),
                    new AlunoCursoDisciplina(3,5),
                    new AlunoCursoDisciplina(4,4),
                    new AlunoCursoDisciplina(4,5),
                    new AlunoCursoDisciplina(5,4),
                    new AlunoCursoDisciplina(5,5),
                    new AlunoCursoDisciplina(6,5),
                    new AlunoCursoDisciplina(6,6),
                    new AlunoCursoDisciplina(6,7),
                    new AlunoCursoDisciplina(7,5),
                    new AlunoCursoDisciplina(7,6),
                    new AlunoCursoDisciplina(7,7)
                });
        }

    }
}
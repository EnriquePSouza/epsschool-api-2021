using System.Collections.Generic;

namespace EpsSchool.Api.Models
{
    public class Disciplina
    {
        public Disciplina() { }
        public Disciplina(int id, string nome, int professorId, int cursoId)
        {
            this.Id = id;
            this.Nome = nome;
            this.ProfessorId = professorId;
            this.CursoId = cursoId;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CargaHoraria { get; set; }
        public int? PrerequisitoId { get; set; } = null;
        public Disciplina Prerequisito { get; set; } // Disciplina de Pré-requisito para a matricula.
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
        public int CursoId { get; set; } // remover.
        
        // TODO - Remodelar o banco tendo curso como base para as disciplinas.
        // Preciso ligar professor com disciplina e aluno com curso e curso com disciplina e não aluno com disciplina.
        public IEnumerable<Curso> Cursos { get; set; } // remover
        public IEnumerable<AlunoDisciplina> AlunosDisciplinas { get; set; } // Remover.
        public IEnumerable<CursoDisciplina> CursosDisciplinas { get; set; } // Remodelagem
    }
}
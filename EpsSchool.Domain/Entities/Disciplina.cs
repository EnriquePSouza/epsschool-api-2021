using System.Collections.Generic;

namespace EpsSchool.Domain.Entities
{
    public class Disciplina
    {
        public Disciplina() { }
        public Disciplina(int id, string nome, int professorId)
        {
            this.Id = id;
            this.Nome = nome;
            this.ProfessorId = professorId;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CargaHoraria { get; set; }
        public int? PrerequisitoId { get; set; } = null;
        public Disciplina Prerequisito { get; set; } // Disciplina de Pré-requisito para a matricula.
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
        public IEnumerable<CursoDisciplina> CursosDisciplinas { get; set; }
    }
}
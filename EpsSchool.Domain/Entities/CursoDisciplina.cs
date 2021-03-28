using System.Collections.Generic;

namespace EpsSchool.Domain.Entities
{
    public class CursoDisciplina
    {
        public CursoDisciplina() { }

        public CursoDisciplina(int id, int cursoId, int disciplinaId)
        {
            this.Id = id;
            this.CursoId = cursoId;
            this.DisciplinaId = disciplinaId;
        }
        public int Id { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
        public int DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }
        public IEnumerable<AlunoCursoDisciplina> AlunosCursosDisciplinas { get; set; }
    }
}
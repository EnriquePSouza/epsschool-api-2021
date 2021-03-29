using System.Collections.Generic;

namespace EpsSchool.Domain.Entities
{
    public class CursoDisciplina : Entity
    {
        public CursoDisciplina(int id, int cursoId, int disciplinaId) : base(id)
        {
            CursoId = cursoId;
            DisciplinaId = disciplinaId;
        }

        public int CursoId { get; private set; }
        public Curso Curso { get; private set; }
        public int DisciplinaId { get; private set; }
        public Disciplina Disciplina { get; private set; }
        public IEnumerable<AlunoCursoDisciplina> AlunosCursosDisciplinas { get; private set; }
    }
}
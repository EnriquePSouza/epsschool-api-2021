using System;

namespace EpsSchool.Domain.Entities
{
    public class AlunoCursoDisciplina
    {
        public AlunoCursoDisciplina() { }
        public AlunoCursoDisciplina(int cursoDisciplinaId, int alunoId)
        {
            AlunoId = alunoId;
            CursoDisciplinaId = cursoDisciplinaId;
            DataInicio = DateTime.Now;
            DataFim = null;
            Nota = null;
        }
        public DateTime DataInicio { get; private set; }
        public DateTime? DataFim { get; private set; }
        public int? Nota { get; private set; }
        public int CursoDisciplinaId { get; private set; }
        public CursoDisciplina CursoDisciplina { get; private set; }
        public int AlunoId { get; private set; }
        public Aluno Aluno { get; private set; }
    }
}
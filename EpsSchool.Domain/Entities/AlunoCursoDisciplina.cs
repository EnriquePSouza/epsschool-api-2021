using System;

namespace EpsSchool.Domain.Entities
{
    public class AlunoCursoDisciplina
    {
        public AlunoCursoDisciplina() { }
        public AlunoCursoDisciplina(int cursoDisciplinaId, int alunoId)
        {
            this.AlunoId = alunoId;
            this.CursoDisciplinaId = cursoDisciplinaId;
        }
        public DateTime DataInicio { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public int? Nota { get; set; } = null;
        public int CursoDisciplinaId { get; set; }
        public CursoDisciplina CursoDisciplina { get; set; }
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace EpsSchool.Api.Models
{
    public class AlunoCursoDisciplina
    {
        public AlunoCursoDisciplina() { }
        public AlunoCursoDisciplina(int cursoDisciplinaId, int alunoId)
        {
            this.CursoDisciplinaId = cursoDisciplinaId;
            this.AlunoId = alunoId;
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
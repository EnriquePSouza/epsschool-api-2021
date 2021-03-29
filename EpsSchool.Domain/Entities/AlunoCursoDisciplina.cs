using System;

namespace EpsSchool.Domain.Entities
{
    public class AlunoCursoDisciplina
    {
        public AlunoCursoDisciplina(int cursoDisciplinaId, int studentId)
        {
            StudentId = studentId;
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
        public int StudentId { get; private set; }
        public Student Student { get; private set; }
    }
}
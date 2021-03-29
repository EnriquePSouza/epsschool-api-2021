using System.Collections.Generic;

namespace EpsSchool.Domain.Entities
{
    public class Disciplina : Entity
    {
        public Disciplina(int id, string nome, int teacherId) : base(id)
        {
            Nome = nome;
            TeacherId = teacherId;
        }

        public string Nome { get; private set; }
        public int CargaHoraria { get; private set; }
        public int TeacherId { get; private set; }
        public Teacher Teacher { get; private set; }
        public IEnumerable<CursoDisciplina> CursosDisciplinas { get; private set; }
    }
}
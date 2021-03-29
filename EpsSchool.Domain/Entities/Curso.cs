using System.Collections.Generic;

namespace EpsSchool.Domain.Entities
{
    public class Curso
    {
        public Curso(int id, string nome)
        {
            Id = id;
            Nome = nome;

        }
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public IEnumerable<CursoDisciplina> CursosDisciplinas { get; private set; }
    }
}
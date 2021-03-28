using System.Collections.Generic;

namespace EpsSchool.Domain.Entities
{
    public class Curso
    {
        public Curso() { }
        public Curso(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;

        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<CursoDisciplina> CursosDisciplinas { get; set; }
    }
}
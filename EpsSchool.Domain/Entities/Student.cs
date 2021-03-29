using System;
using System.Collections.Generic;

namespace EpsSchool.Domain.Entities
{
    public class Student : Person
    {
        public Student(int id, int registration, string nome, string sobrenome, string telefone, DateTime dataNascimento)
            : base(id, registration, nome, sobrenome, telefone, dataNascimento)
        {
            DataInicio = DateTime.Now;
            DataFim = null;
            Ativo = true;
        }
        
        public DateTime DataInicio { get; private set; }
        public DateTime? DataFim { get; private set; }
        public bool Ativo { get; private set; }
        public IEnumerable<AlunoCursoDisciplina> AlunosCursosDisciplinas { get; private set; }

        public void IsInactive()
        {
            Ativo = false;
        }

        public void IsActive()
        {
            Ativo = true;
        }
    }
}
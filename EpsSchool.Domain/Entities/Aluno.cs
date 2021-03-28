using System;
using System.Collections.Generic;

namespace EpsSchool.Domain.Entities
{
    public class Aluno : Entity
    {
        public Aluno(int id, int matricula, string nome, string sobrenome, string telefone, DateTime dataNascimento)
            : base(id)
        {
            Matricula = matricula;
            Nome = nome;
            Sobrenome = sobrenome;
            Telefone = telefone;
            DataNascimento = dataNascimento;
            DataInicio = DateTime.Now;
            DataFim = null;
            Ativo = true;
        }
        public int Matricula { get; private set; }
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string Telefone { get; private set; }
        public DateTime DataNascimento { get; private set; }
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
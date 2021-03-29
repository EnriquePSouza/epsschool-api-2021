using System;

namespace EpsSchool.Domain.Entities
{
    public abstract class Person : Entity
    {
        protected Person(int id, int registration, string nome, string sobrenome, string telefone, DateTime dataNascimento) : base(id)
        {
            Registration = registration;
            Nome = nome;
            Sobrenome = sobrenome;
            Telefone = telefone;
            DataNascimento = dataNascimento;
        }

        public int Registration { get; private set; }
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string Telefone { get; private set; }
        public DateTime DataNascimento { get; private set; }
    }
}
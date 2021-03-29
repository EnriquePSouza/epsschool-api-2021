using System;

namespace EpsSchool.Shared.Entities
{
    public abstract class Person : Entity
    {
        protected Person(int id, int registration, string name, string surname, string phoneNumber, DateTime birthdate) : base(id)
        {
            Registration = registration;
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Birthdate = birthdate;
        }

        public int Registration { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string PhoneNumber { get; private set; }
        public DateTime Birthdate { get; private set; }
    }
} 
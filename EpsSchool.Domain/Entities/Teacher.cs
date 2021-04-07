using System.Collections.Generic;
using EpsSchool.Shared.Entities;

namespace EpsSchool.Domain.Entities
{
    public class Teacher : Person
    {
        public Teacher() { }
        public Teacher(string name, string surname, string phoneNumber)
            : base(name, surname, phoneNumber) { }
        public IEnumerable<Subject> Subject { get; set; }
    }
}
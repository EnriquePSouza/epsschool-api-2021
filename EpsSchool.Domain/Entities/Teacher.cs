using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EpsSchool.Shared.Entities;

namespace EpsSchool.Domain.Entities
{
    public class Teacher : Person
    {
        public Teacher(int id, int registration, string name, string surname, string phoneNumber, DateTime birthdate)
            : base(id, registration, name, surname, phoneNumber, birthdate) { }

        [Required]
        [Range(1, int.MaxValue)]
        public int SubjectId { get; private set; }
        
        public IEnumerable<Subject> Subjects { get; private set; }
    }
}
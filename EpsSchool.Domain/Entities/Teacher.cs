using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EpsSchool.Shared.Entities;

namespace EpsSchool.Domain.Entities
{
    public class Teacher : Person
    {
        public Teacher(int id, int registration, string name, string surname, string phoneNumber)
            : base(id, registration, name, surname, phoneNumber) { }

        [Required]
        [Range(1, int.MaxValue)]
        public int SubjectId { get; set; }
        
        public IEnumerable<Subject> Subjects { get; set; }
    }
}
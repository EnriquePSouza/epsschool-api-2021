using System;
using System.ComponentModel.DataAnnotations;
using EpsSchool.Shared.Entities;

namespace EpsSchool.Domain.Entities
{
    public class Teacher : Person
    {
        public Teacher() { }
        public Teacher(string firstName, string lastName, string phoneNumber, Guid subjectId)
            : base(firstName, lastName, phoneNumber)
        {
            SubjectId = subjectId;
        }

        [Required]
        [Range(1, int.MaxValue)]
        public Guid SubjectId { get; set; }

        public Subject Subject { get; set; }
    }
}
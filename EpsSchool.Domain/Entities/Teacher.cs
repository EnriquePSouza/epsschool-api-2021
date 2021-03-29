using System;
using System.Collections.Generic;
using EpsSchool.Shared.Entities;

namespace EpsSchool.Domain.Entities
{
    public class Teacher : Person
    {
        public Teacher(int id, int registration, string name, string surname, string phoneNumber, DateTime birthdate)
            : base(id, registration, name, surname, phoneNumber, birthdate)
        {
            StartDate = DateTime.Now;
            EndDate = null;
            Status = true;
        }

        public DateTime StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public bool Status { get; private set; }
        public int SubjectId { get; private set; }
        public IEnumerable<Subject> Subjects { get; private set; }
    }
}
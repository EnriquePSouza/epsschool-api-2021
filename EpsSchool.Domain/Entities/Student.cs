using System;
using System.Collections.Generic;
using EpsSchool.Shared.Entities;

namespace EpsSchool.Domain.Entities
{
    public class Student : Person
    {
        public Student(int id, int registration, string name, string surname, string phoneNumber, DateTime birthdate)
            : base(id, registration, name, surname, phoneNumber, birthdate)
        {
            StartDate = DateTime.Now;
            EndDate = null;
            Status = true;
        }
        
        public DateTime StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public bool Status { get; private set; }
        public IEnumerable<StudentCourseSubject> StudentsCoursesSubjects { get; private set; }

        public void IsInactive()
        {
            Status = false;
        }

        public void IsActive()
        {
            Status = true;
        }
    }
}
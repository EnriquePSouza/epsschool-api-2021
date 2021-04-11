using System;
using System.Collections.Generic;
using EpsSchool.Shared.Entities;

namespace EpsSchool.Domain.Entities
{
    public class Student : Person
    {
        public Student() { }
        public Student(string firstName, string lastName, string phoneNumber, DateTime birthDate)
            : base(firstName, lastName, phoneNumber)
        {
            BirthDate = birthDate;
        }
        public DateTime BirthDate { get; set; }

        public IEnumerable<StudentCourseSubject> StudentsCoursesSubjects { get; set; }
    }
}
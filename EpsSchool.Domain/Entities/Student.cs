using System;
using System.Collections.Generic;
using EpsSchool.Shared.Entities;

namespace EpsSchool.Domain.Entities
{
    public class Student : Person
    {
        public Student(string name, string surname, string phoneNumber, DateTime birthDate)
            : base(name, surname, phoneNumber)
            {
                BirthDate = birthDate;
            }

            public DateTime BirthDate { get; set; }
            
            public IEnumerable<StudentCourseSubject> StudentsCoursesSubjects { get; set; }
    }
}
using System;
using System.Collections.Generic;
using EpsSchool.Shared.Entities;

namespace EpsSchool.Domain.Entities
{
    public class Student : Person
    {
        public Student(string name, string surname, string phoneNumber, DateTime birthdate)
            : base(name, surname, phoneNumber)
            {
                Birthdate = birthdate;
            }

            public DateTime Birthdate { get; set; }
            
            public IEnumerable<StudentCourseSubject> StudentsCoursesSubjects { get; set; }
    }
}
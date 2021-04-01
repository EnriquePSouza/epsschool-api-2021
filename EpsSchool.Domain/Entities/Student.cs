using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EpsSchool.Shared.Entities;

namespace EpsSchool.Domain.Entities
{
    public class Student : Person
    {
        public Student(int id, int registration, string name, string surname, string phoneNumber, DateTime birthdate)
            : base(id, registration, name, surname, phoneNumber)
            {
                Birthdate = birthdate;
            }

            public DateTime Birthdate { get; set; }
            
            public IEnumerable<StudentCourseSubject> StudentsCoursesSubjects { get; set; }
    }
}
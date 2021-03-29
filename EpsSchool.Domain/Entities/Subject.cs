using System.Collections.Generic;
using EpsSchool.Shared.Entities;

namespace EpsSchool.Domain.Entities
{
    public class Subject : Entity
    {
        public Subject(int id, string name, int teacherId) : base(id)
        {
            Name = name;
            TeacherId = teacherId;
        }

        public string Name { get; private set; }
        public int CargaHoraria { get; private set; }
        public int TeacherId { get; private set; }
        public Teacher Teacher { get; private set; }
        public IEnumerable<CourseSubject> CoursesSubjects { get; private set; }
    }
}
using System.Collections.Generic;

namespace EpsSchool.Domain.Entities
{
    public class Course
    {
        public Course(int id, string nome)
        {
            Id = id;
            Nome = nome;

        }
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public IEnumerable<CourseSubject> CoursesSubjects { get; private set; }
    }
}
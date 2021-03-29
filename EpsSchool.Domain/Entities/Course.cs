using System.Collections.Generic;

namespace EpsSchool.Domain.Entities
{
    public class Course
    {
        public Course(int id, string name)
        {
            Id = id;
            Name = name;

        }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public IEnumerable<CourseSubject> CoursesSubjects { get; private set; }
    }
}
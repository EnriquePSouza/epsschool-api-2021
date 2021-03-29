using System.Collections.Generic;
using EpsSchool.Shared.Entities;

namespace EpsSchool.Domain.Entities
{
    public class CourseSubject : Entity
    {
        public CourseSubject(int id, int courseId, int subjectId) : base(id)
        {
            CourseId = courseId;
            SubjectId = subjectId;
        }

        public int CourseId { get; private set; }
        public Course Course { get; private set; }
        public int SubjectId { get; private set; }
        public Subject Subject { get; private set; }
        public IEnumerable<StudentCourseSubject> StudentsCoursesSubjects { get; private set; }
    }
}
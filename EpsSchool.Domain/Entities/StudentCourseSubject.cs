using System;

namespace EpsSchool.Domain.Entities
{
    public class StudentCourseSubject
    {
        public StudentCourseSubject(int courseSubjectId, int studentId)
        {
            StudentId = studentId;
            CourseSubjectId = courseSubjectId;
            DataInicio = DateTime.Now;
            DataFim = null;
            Nota = null;
        }
        public DateTime DataInicio { get; private set; }
        public DateTime? DataFim { get; private set; }
        public int? Nota { get; private set; }
        public int CourseSubjectId { get; private set; }
        public CourseSubject CourseSubject { get; private set; }
        public int StudentId { get; private set; }
        public Student Student { get; private set; }
    }
}
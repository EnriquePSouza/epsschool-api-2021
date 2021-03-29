using System;

namespace EpsSchool.Domain.Entities
{
    public class StudentCourseSubject
    {
        public StudentCourseSubject(int courseSubjectId, int studentId)
        {
            StudentId = studentId;
            CourseSubjectId = courseSubjectId;
            StartDate = DateTime.Now;
            EndDate = null;
            Grade = null;
        }
        public DateTime StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public int? Grade { get; private set; }
        public int CourseSubjectId { get; private set; }
        public CourseSubject CourseSubject { get; private set; }
        public int StudentId { get; private set; }
        public Student Student { get; private set; }
    }
}
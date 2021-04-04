using System.Collections.Generic;

namespace EpsSchool.Domain.Commands
{
    public class SubjectCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Workload { get; set; }
        public int TeacherId { get; set; }
        public TeacherCommand Teacher { get; set; }
        public IEnumerable<CourseSubjectCommand> CoursesSubjects { get; set; }
    }
}
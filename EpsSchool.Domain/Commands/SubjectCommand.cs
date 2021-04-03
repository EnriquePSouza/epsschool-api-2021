using System.Collections.Generic;

namespace EpsSchool.Domain.Commands
{
    public class SubjectCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Workload { get; set; }
        public int TeacherId { get; set; }
        public IEnumerable<TeacherCommand> Teacher { get; set; }
        public int CourseId { get; set; }
        public IEnumerable<CourseCommand> Course { get; set; }
        public IEnumerable<StudentCommand> Students { get; set; }
    }
}
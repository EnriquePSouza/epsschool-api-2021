using System;

namespace EpsSchool.Domain.Commands
{
    public class CourseSubjectCommand
    {
        public Guid CourseId { get; set; }
        public CourseCommand Course { get; set; }
        public Guid SubjectId { get; set; }
        public SubjectCommand Subject { get; set; }
        
    }
}
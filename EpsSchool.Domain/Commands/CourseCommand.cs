using System;
using System.Collections.Generic;

namespace EpsSchool.Domain.Commands
{
    public class CourseCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CourseSubjectCommand> CoursesSubjects { get; set; }
    }
}
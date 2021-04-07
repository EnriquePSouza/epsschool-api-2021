using System;
using System.Collections.Generic;

namespace EpsSchool.Domain.Dtos
{
    public class CourseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CourseSubjectDto> CoursesSubjects { get; set; }
    }
}
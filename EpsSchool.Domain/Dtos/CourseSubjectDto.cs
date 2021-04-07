using System;

namespace EpsSchool.Domain.Dtos
{
    public class CourseSubjectDto
    {
        public Guid CourseId { get; set; }
        public CourseDto Course { get; set; }
        public Guid SubjectId { get; set; }
        public SubjectDto Subject { get; set; }
        
    }
}
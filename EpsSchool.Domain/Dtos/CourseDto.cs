using System.Collections.Generic;

namespace EpsSchool.Domain.Dtos
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<SubjectDto> Subjects { get; set; }
    }
}
using System.Collections.Generic;

namespace EpsSchool.Domain.Dtos
{
    public class TeacherDto
    {
        public int Id { get; set; }
        public int Registration { get; set; }
        public string Name { get; set; }
        public string phoneNumber { get; set; }
        public bool Status { get; set; } = true;
        public IEnumerable<SubjectDto> Subjects { get; set; }
    }
}
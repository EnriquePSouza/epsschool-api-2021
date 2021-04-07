using System.Collections.Generic;

namespace EpsSchool.Domain.Dtos
{
    public class TeacherDto
    {
        public int Id { get; set; }
        public int Enrollment { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public bool Status { get; set; } = true;
        public IEnumerable<SubjectDto> Subject { get; set; }
    }
}
using System.Collections.Generic;

namespace EpsSchool.Domain.Commands
{
    public class TeacherCommand
    {
        public int Id { get; set; }
        public int Enrollment { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public bool Status { get; set; } = true;
        public IEnumerable<SubjectCommand> Subject { get; set; }
    }
}
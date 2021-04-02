using System.Collections.Generic;

namespace EpsSchool.Domain.Commands
{
    public class TeacherCommand
    {
        public int Id { get; set; }
        public int Registration { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public bool Status { get; set; } = true;
        public IEnumerable<SubjectCommand> Subjects { get; set; }
    }
}
namespace EpsSchool.Domain.Commands
{
    public class CourseSubjectCommand
    {
        public int CourseId { get; set; }
        public CourseCommand Course { get; set; }
        public int SubjectId { get; set; }
        public SubjectCommand Subject { get; set; }
        
    }
}
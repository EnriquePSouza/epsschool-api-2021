namespace EpsSchool.Domain.Dtos
{
    public class StudentPatchDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string phoneNumber { get; set; }
        public bool Status { get; set; } = true;
    }
}
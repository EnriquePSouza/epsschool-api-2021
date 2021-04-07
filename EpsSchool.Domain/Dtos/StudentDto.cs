using System;

namespace EpsSchool.Domain.Dtos
{
    public class StudentDto
    {
        public int Id { get; set; }
        public int Enrollment { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public DateTime StartDate { get; set; }
        public bool Status { get; set; }
    }
}
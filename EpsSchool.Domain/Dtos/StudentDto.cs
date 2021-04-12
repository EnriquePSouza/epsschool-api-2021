using System;

namespace EpsSchool.Domain.Dtos
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public string Enrollment { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Status { get; set; }
    }
}
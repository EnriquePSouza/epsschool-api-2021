using System;
using System.ComponentModel.DataAnnotations;

namespace EpsSchool.Shared.Entities
{
    public abstract class Person : Entity
    {
        protected Person() { }
        protected Person(string name, string surname, string phoneNumber)
        {
            Enrollment = DateTime.Now.ToString("yydd") +
                           Id.GetHashCode().ToString().Replace("-", "0").Substring(0, 4);
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            StartDate = DateTime.Now;
            EndDate = null;
            Status = true;
        }

        [Required]
        [Range(1, int.MaxValue)]
        public string Enrollment { get; set; }

        [Required]
        [MaxLength(120)]
        public string Name { get; set; }

        [Required]
        [MaxLength(120)]
        public string Surname { get; set; }

        [Required]
        [MaxLength(120)]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [DataType("bit")]
        public bool Status { get; set; }
    }
}
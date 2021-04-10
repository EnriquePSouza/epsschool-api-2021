using System;
using System.ComponentModel.DataAnnotations;

namespace EpsSchool.Shared.Entities
{
    public abstract class Person : Entity
    {
        protected Person() { }
        protected Person(string firstName, string lastName, string phoneNumber)
        {
            Enrollment = DateTime.Now.ToString("yydd") +
                           Id.GetHashCode().ToString().Replace("-", "51").Substring(0, 5);
            FirstName = firstName;
            LastName = lastName;
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
        public string FirstName { get; set; }

        [Required]
        [MaxLength(120)]
        public string LastName { get; set; }

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
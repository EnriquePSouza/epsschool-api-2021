using System;
using System.ComponentModel.DataAnnotations;

namespace EpsSchool.Shared.Entities
{
    public abstract class Person : Entity
    {
        protected Person(int id, int registration, string name, string surname, string phoneNumber) : base(id)
        {
            Registration = registration;
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            StartDate = DateTime.Now;
            EndDate = null;
            Status = true;
        }

        [Required]
        [Range(1, int.MaxValue)]
        public int Registration { get; set; }

        [Required]
        [MaxLength(120)]
        public string Name { get; set; }

        [Required]
        [MaxLength(120)]
        public string Surname { get; set; }

        [Required]
        [MaxLength(120)]
        public string PhoneNumber { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [DataType("bit")]
        public bool Status { get; set; }
    }
}
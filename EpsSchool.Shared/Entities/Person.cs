using System;
using System.ComponentModel.DataAnnotations;

namespace EpsSchool.Shared.Entities
{
    public abstract class Person : Entity
    {
        protected Person(int id, int registration, string name, string surname, string phoneNumber, DateTime birthdate) : base(id)
        {
            Registration = registration;
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Birthdate = birthdate;
            StartDate = DateTime.Now;
            EndDate = null;
            Status = true;
        }

        [Required]
        [Range(1, int.MaxValue)]
        public int Registration { get; private set; }

        [Required]
        [MaxLength(120)]
        public string Name { get; private set; }

        [Required]
        [MaxLength(120)]
        public string Surname { get; private set; }

        [Required]
        [MaxLength(120)]
        public string PhoneNumber { get; private set; }

        public DateTime Birthdate { get; private set; }

        public DateTime StartDate { get; private set; }

        public DateTime? EndDate { get; private set; }

        [DataType("bit")]
        public bool Status { get; private set; }

        public void IsInactive()
        {
            Status = false;
        }

        public void IsActive()
        {
            Status = true;
        }

        public void ChangeStatus(bool status) // VERIFY
        {
            if (status.Equals(true))
            {
                IsActive();
            }
            else
            {
                IsInactive();
            }
        }
    }
}
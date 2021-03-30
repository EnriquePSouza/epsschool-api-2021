using System;
using EpsSchool.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace EpsSchool.Domain.Commands
{
    public class CreateStudentCommand : Notifiable, ICommand
    {
        public CreateStudentCommand() { }

        public CreateStudentCommand(int id, int registration, string name, string surname, string phoneNumber,
            DateTime birthdate, DateTime startDate, bool status)
        {
            Id = id;
            Registration = registration;
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Birthdate = birthdate;
            StartDate = DateTime.Now;
            EndDate = null;
            Status = true;

        }
        public int Id { get; set; }
        public int Registration { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool Status { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Name, 10, "Nome", "Por favor, informe ao menos o primeiro e segundo nome do aluno!")
                    .HasMaxLen(Name, 40, "Nome", "O nome não pode conter mais que 40 caracteres!")
            );
        }
    }
}
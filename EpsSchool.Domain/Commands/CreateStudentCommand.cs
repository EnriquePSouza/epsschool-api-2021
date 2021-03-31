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
            DateTime birthdate)
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
                    .IsGreaterThan(0, Id, "Código do Aluno", "Informe um código de aluno válido!")
                    .HasMinLen(Name, 5, "Nome", "Informe o nome do aluno!")
                    .HasMaxLen(Name, 20,"Nome", "O nome não pode ter mais que 20 caracteres!")
                    .HasMinLen(Surname, 5, "Sobrenome", "Informe o sobrenome do aluno!")
                    .HasMaxLen(Surname, 20,"Sobrenome", "O sobrenome não pode ter mais que 20 caracteres!")
                    .HasMinLen(PhoneNumber, 8, "Telefone", "Informe um telefone válido contendo apenas numeros!")
                    .HasMaxLen(PhoneNumber, 12,"Telefone", "Informe um telefone válido contendo apenas numeros!")
                    .IsNotNull(Status, "Status", "Informe se o aluno está ou não ativo na instituição!")
            );
        }
    }
}
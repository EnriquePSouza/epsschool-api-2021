using System;
using EpsSchool.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace EpsSchool.Domain.Commands
{
    public class UpdateStudentCommand : Notifiable, ICommand
    {
        public UpdateStudentCommand() { }
        public UpdateStudentCommand(Guid id, string firstName, string lastName, string phoneNumber, bool status)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Status = status;
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public bool Status { get; set; }

        // TODO - Verify if needs to update course too.

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotEmpty(Id, "Código do Aluno", "Informe o código de aluno válido!")
                    .HasMinLen(FirstName, 5, "Nome", "Informe o nome do aluno!")
                    .HasMaxLen(FirstName, 20,"Nome", "O nome não pode ter mais que 20 caracteres!")
                    .HasMinLen(LastName, 5, "Sobrenome", "Informe o sobrenome do aluno!")
                    .HasMaxLen(LastName, 20,"Sobrenome", "O sobrenome não pode ter mais que 20 caracteres!")
                    .HasMinLen(PhoneNumber, 8, "Telefone", "Informe um telefone válido contendo apenas numeros!")
                    .HasMaxLen(PhoneNumber, 12,"Telefone", "Informe um telefone válido contendo apenas numeros!")
                    .IsNotNullOrEmpty(Status.ToString(), "Status", "Informe se o Aluno está ou não ativo na instituição!")
            );
        }
    }
}
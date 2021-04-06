using System;
using EpsSchool.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace EpsSchool.Domain.Commands
{
    public class UpdateStudentCommand : Notifiable, ICommand
    {
        public UpdateStudentCommand() { }
        public UpdateStudentCommand(Guid id, string name, string surname, string phoneNumber, bool status)
        {
            Id = id;
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Status = true;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public bool Status { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNull(Id, "Código do Aluno", "Informe o código de aluno válido!")
                    .HasMinLen(Name, 5, "Nome", "Informe o nome do aluno!")
                    .HasMaxLen(Name, 20,"Nome", "O nome não pode ter mais que 20 caracteres!")
                    .HasMinLen(Surname, 5, "Sobrenome", "Informe o sobrenome do aluno!")
                    .HasMaxLen(Surname, 20,"Sobrenome", "O sobrenome não pode ter mais que 20 caracteres!")
                    .HasMinLen(PhoneNumber, 8, "Telefone", "Informe um telefone válido contendo apenas numeros!")
                    .HasMaxLen(PhoneNumber, 12,"Telefone", "Informe um telefone válido contendo apenas numeros!")
                    .IsNotNull(Status, "Status", "Informe se o Aluno está ou não ativo na instituição!")
            );
        }
    }
}
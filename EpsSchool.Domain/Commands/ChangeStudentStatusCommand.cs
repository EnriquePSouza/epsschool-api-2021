using System;
using EpsSchool.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace EpsSchool.Domain.Commands
{
    public class ChangeStudentStatusCommand : Notifiable, ICommand
    {
        public ChangeStudentStatusCommand() { }
        public ChangeStudentStatusCommand(Guid id, bool status)
        {
            Id = id;
            Status = status;
        }

        public Guid Id { get; set; }
        public bool Status { get; set; }
        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(Status.ToString(), "Status", "Informe se o Aluno está ou não ativo na instituição!")
                    .IsNotEmpty(Id, "Código do Aluno", "Informe o Código do Aluno!")
            );
        }
    }
}
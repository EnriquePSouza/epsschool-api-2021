using System;
using EpsSchool.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace EpsSchool.Domain.Commands
{
    public class ChangeTeacherStatusCommand : Notifiable, ICommand
    {
        public ChangeTeacherStatusCommand(){}
        public ChangeTeacherStatusCommand(Guid id, bool status)
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
                    .IsNotNull(Status, "Status", "Informe se o Professor está ou não ativo na instituição!")
                    .IsNotNull(Id, "Código do Professor", "Informe o Código do Professor!")
            );
        }
    }
}
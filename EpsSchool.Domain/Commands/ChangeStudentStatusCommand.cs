using EpsSchool.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace EpsSchool.Domain.Commands
{
    public class ChangeStudentStatusCommand : Notifiable, ICommand
    {
        public ChangeStudentStatusCommand(){}
        public ChangeStudentStatusCommand(bool status)
        {
            Status = status;
        }

        public bool Status { get; set; }
        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNull(Status, "Status", "Informe se o Aluno está ou não ativo na instituição!")
            );
        }
    }
}
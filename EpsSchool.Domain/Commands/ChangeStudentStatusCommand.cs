using EpsSchool.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace EpsSchool.Domain.Commands
{
    public class ChangeStudentStatusCommand : Notifiable, ICommand
    {
        public ChangeStudentStatusCommand(){}
        public ChangeStudentStatusCommand(int id, bool status)
        {
            Id = id;
            Status = status;
        }

        public int Id { get; set; }
        public bool Status { get; set; }
        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNull(Status, "Status", "Informe se o Aluno está ou não ativo na instituição!")
                    .IsGreaterThan(Id, 0, "Código do Aluno", "Informe o Código do Aluno!")
            );
        }
    }
}
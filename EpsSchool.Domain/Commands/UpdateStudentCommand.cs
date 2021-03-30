using EpsSchool.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace EpsSchool.Domain.Commands
{
    public class UpdateStudentCommand : Notifiable, ICommand
    {
        public UpdateStudentCommand() { }
        public UpdateStudentCommand(int id, string name, string surname, string phoneNumber, bool status)
        {
            Id = id;
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Status = true;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
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
using System;
using EpsSchool.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace EpsSchool.Domain.Commands
{
    /// <summary>
    /// Este é o command para efetuar o registro de uma disciplina no banco de dados
    /// </summary>
    public class CreateSubjectCommand : Notifiable, ICommand
    {
        public CreateSubjectCommand() { }

        public CreateSubjectCommand(string name)
        {
            Name = name;

        }
        /// <summary>
        /// Nome da disciplina.
        /// </summary>
        /// <value></value>
        public string Name { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Name, 3, "Nome", "Informe o nome da disciplina!")
                    .HasMaxLen(Name, 20,"Nome", "O nome não pode ter mais que 20 caracteres!")
            );
        }
    }
}
using System;
using EpsSchool.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace EpsSchool.Domain.Commands
{
    /// <summary>
    /// Este é o command para efetuar o registro de um curso no banco de dados
    /// </summary>
    public class CreateCourseCommand : Notifiable, ICommand
    {
        public CreateCourseCommand() { }

        public CreateCourseCommand(string name)
        {
            Name = name;

        }
        /// <summary>
        /// Nome do curso.
        /// </summary>
        /// <value></value>
        public string Name { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Name, 3, "Nome", "Informe o nome do curso!")
                    .HasMaxLen(Name, 20,"Nome", "O nome não pode ter mais que 20 caracteres!")
            );
        }
    }
}
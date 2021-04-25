using System;
using EpsSchool.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace EpsSchool.Domain.Commands
{
    /// <summary>
    /// Este é o DTO para efetuar o registro de um Aluno no banco de dados
    /// </summary>
    public class CreateCourseCommand : Notifiable, ICommand
    {
        public CreateCourseCommand() { }

        public CreateCourseCommand(string name)
        {
            Name = name;

        }
        /// <summary>
        /// Primeiro nome do aluno.
        /// </summary>
        /// <value></value>
        public string Name { get; set; }
        /// <summary>
        /// Segundo nome do aluno.
        /// </summary>
        /// <value></value>

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
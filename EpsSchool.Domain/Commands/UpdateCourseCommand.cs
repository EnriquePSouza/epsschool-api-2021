using System;
using EpsSchool.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace EpsSchool.Domain.Commands
{
    /// <summary>
    /// Este é o command para efetuar a atualização de um curso no banco de dados
    /// </summary>
    public class UpdateCourseCommand : Notifiable, ICommand
    {
        public UpdateCourseCommand() { }

        public UpdateCourseCommand(Guid id, string name)
        {
            Id = id;
            Name = name;

        }
        /// <summary>
        /// Código identificador do curso.
        /// </summary>
        /// <value></value>
        public Guid Id { get; set; }

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
                    .IsNotEmpty(Id, "Código do Curso", "Informe o código de curso válido!")
                    .HasMinLen(Name, 3, "Nome", "Informe o nome do curso!")
                    .HasMaxLen(Name, 20,"Nome", "O nome não pode ter mais que 20 caracteres!")
            );
        }
    }
}
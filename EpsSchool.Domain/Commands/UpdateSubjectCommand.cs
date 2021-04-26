using System;
using EpsSchool.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace EpsSchool.Domain.Commands
{
    /// <summary>
    /// Este é o command para efetuar a atualização de uma disciplina no banco de dados
    /// </summary>
    public class UpdateSubjectCommand : Notifiable, ICommand
    {
        public UpdateSubjectCommand() { }

        public UpdateSubjectCommand(Guid id, string name)
        {
            Id = id;
            Name = name;

        }
        /// <summary>
        /// Código identificador da disciplina.
        /// </summary>
        /// <value></value>
        public Guid Id { get; set; }

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
                    .IsNotEmpty(Id, "Código da Disciplina", "Informe o código de disciplina válido!")
                    .HasMinLen(Name, 3, "Nome", "Informe o nome da disciplina!")
                    .HasMaxLen(Name, 20,"Nome", "O nome não pode ter mais que 20 caracteres!")
            );
        }
    }
}
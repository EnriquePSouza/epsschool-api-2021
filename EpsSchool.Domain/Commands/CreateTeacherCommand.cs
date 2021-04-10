using System;
using EpsSchool.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace EpsSchool.Domain.Commands
{
    /// <summary>
    /// Este é o DTO para efetuar o registro de um Professor no banco de dados.
    /// </summary>
    public class CreateTeacherCommand : Notifiable, ICommand
    {
        public CreateTeacherCommand() { }

        public CreateTeacherCommand(string firstName, string lastName, string phoneNumber, Guid subjectId)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            StartDate = DateTime.Now;
            EndDate = null;
            Status = true;
            SubjectId = subjectId;
        }
        /// <summary>
        /// Primeiro nome do professor.
        /// </summary>
        /// <value></value>
        public string FirstName { get; set; }
        /// <summary>
        /// Segundo nome do professor.
        /// </summary>
        /// <value></value>
        public string LastName { get; set; }
        /// <summary>
        /// Telefone do professor.
        /// </summary>
        /// <value></value>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Data em que o professor começou a dar aulas na instituição.
        /// </summary>
        /// <value></value>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Data em que o professor parou de dar aulas na instituição.
        /// </summary>
        /// <value></value>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// Informa se o professor está ativo ou naõ na instituição.
        /// </summary>
        /// <value></value>
        public bool Status { get; set; }
        /// <summary>
        /// Código identificador da matéria que o professor leciona.
        /// </summary>
        /// <value></value>
        public Guid SubjectId { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(FirstName, 5, "Nome", "Informe o nome do professor!")
                    .HasMaxLen(FirstName, 20,"Nome", "O nome não pode ter mais que 20 caracteres!")
                    .HasMinLen(LastName, 5, "Sobrenome", "Informe o sobrenome do professor!")
                    .HasMaxLen(LastName, 20,"Sobrenome", "O sobrenome não pode ter mais que 20 caracteres!")
                    .HasMinLen(PhoneNumber, 8, "Telefone", "Informe um telefone válido contendo apenas numeros!")
                    .HasMaxLen(PhoneNumber, 12,"Telefone", "Informe um telefone válido contendo apenas numeros!")
                    .IsNotNullOrEmpty(Status.ToString(), "Status", "Informe se o professor está ou não ativo na instituição!")
                    .IsNotEmpty(SubjectId, "Código da Matéria", "Informe o código da matéria que o professor leciona!")
            );
        }
    }
}
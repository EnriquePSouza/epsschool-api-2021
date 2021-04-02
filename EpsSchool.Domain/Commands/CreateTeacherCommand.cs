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

        public CreateTeacherCommand(int id, int registration, string name, string surname, string phoneNumber)
        {
            Id = id;
            Registration = registration;
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            StartDate = DateTime.Now;
            EndDate = null;
            Status = true;

        }
        /// <summary>
        /// Código identificador e chave do Banco.
        /// </summary>
        /// <value></value>
        public int Id { get; set; }
        /// <summary>
        /// Código identificador para outras atividades da instituição.
        /// </summary>
        /// <value></value>
        public int Registration { get; set; }
        /// <summary>
        /// Primeiro nome do professor.
        /// </summary>
        /// <value></value>
        public string Name { get; set; }
        /// <summary>
        /// Segundo nome do professor.
        /// </summary>
        /// <value></value>
        public string Surname { get; set; }
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

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsGreaterThan(0, Id, "Código do Professor", "Informe um código de professor válido!")
                    .HasMinLen(Name, 5, "Nome", "Informe o nome do professor!")
                    .HasMaxLen(Name, 20,"Nome", "O nome não pode ter mais que 20 caracteres!")
                    .HasMinLen(Surname, 5, "Sobrenome", "Informe o sobrenome do professor!")
                    .HasMaxLen(Surname, 20,"Sobrenome", "O sobrenome não pode ter mais que 20 caracteres!")
                    .HasMinLen(PhoneNumber, 8, "Telefone", "Informe um telefone válido contendo apenas numeros!")
                    .HasMaxLen(PhoneNumber, 12,"Telefone", "Informe um telefone válido contendo apenas numeros!")
                    .IsNotNull(Status, "Status", "Informe se o professor está ou não ativo na instituição!")
            );
        }
    }
}
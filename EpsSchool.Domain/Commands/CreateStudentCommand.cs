using System;
using EpsSchool.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace EpsSchool.Domain.Commands
{
    /// <summary>
    /// Este é o DTO para efetuar o registro de um Aluno no banco de dados
    /// </summary>
    public class CreateStudentCommand : Notifiable, ICommand
    {
        public CreateStudentCommand() { }

        public CreateStudentCommand(int id, int registration, string name, string surname, string phoneNumber,
            DateTime birthdate)
        {
            Id = id;
            Registration = registration;
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Birthdate = birthdate;
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
        /// Primeiro nome do aluno.
        /// </summary>
        /// <value></value>
        public string Name { get; set; }
        /// <summary>
        /// Segundo nome do aluno.
        /// </summary>
        /// <value></value>
        public string Surname { get; set; }
        /// <summary>
        /// Telefone do aluno.
        /// </summary>
        /// <value></value>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Data em que o aluno nasceu.
        /// </summary>
        /// <value></value>
        public DateTime Birthdate { get; set; }
        /// <summary>
        /// Data em que o aluno foi matrículado na instituição.
        /// </summary>
        /// <value></value>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Data em que o aluno cancelou sua matrícula.
        /// </summary>
        /// <value></value>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// Informa se o aluno está ativo ou não na instuição.
        /// </summary>
        /// <value></value>
        public bool Status { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsGreaterThan(0, Id, "Código do Aluno", "Informe um código de aluno válido!")
                    .HasMinLen(Name, 5, "Nome", "Informe o nome do aluno!")
                    .HasMaxLen(Name, 20,"Nome", "O nome não pode ter mais que 20 caracteres!")
                    .HasMinLen(Surname, 5, "Sobrenome", "Informe o sobrenome do aluno!")
                    .HasMaxLen(Surname, 20,"Sobrenome", "O sobrenome não pode ter mais que 20 caracteres!")
                    .HasMinLen(PhoneNumber, 8, "Telefone", "Informe um telefone válido contendo apenas numeros!")
                    .HasMaxLen(PhoneNumber, 12,"Telefone", "Informe um telefone válido contendo apenas numeros!")
                    .IsNotNull(Status, "Status", "Informe se o aluno está ou não ativo na instituição!")
            );
        }
    }
}
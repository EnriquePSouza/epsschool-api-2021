using System;
using EpsSchool.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace EpsSchool.Domain.Commands
{
    /// <summary>
    /// Este é o command para efetuar o registro de um Aluno no banco de dados
    /// </summary>
    public class CreateStudentCommand : Notifiable, ICommand
    {
        public CreateStudentCommand() { }

        public CreateStudentCommand(string firstName, string lastName, string phoneNumber,
            DateTime birthDate, Guid courseId)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            BirthDate = birthDate;
            StartDate = DateTime.Now;
            EndDate = null;
            Status = true;
            CourseId = courseId; 

        }
        /// <summary>
        /// Primeiro nome do aluno.
        /// </summary>
        /// <value></value>
        public string FirstName { get; set; }
        /// <summary>
        /// Segundo nome do aluno.
        /// </summary>
        /// <value></value>
        public string LastName { get; set; }
        /// <summary>
        /// Telefone do aluno.
        /// </summary>
        /// <value></value>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Data em que o aluno nasceu.
        /// </summary>
        /// <value></value>
        public DateTime BirthDate { get; set; }
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
        /// <summary>
        /// Informa em qual curso o aluno foi matrículado.
        /// </summary>
        /// <value></value>
        public Guid CourseId { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(FirstName, 3, "Nome", "Informe o nome do aluno!")
                    .HasMaxLen(FirstName, 20,"Nome", "O nome não pode ter mais que 20 caracteres!")
                    .HasMinLen(LastName, 3, "Sobrenome", "Informe o sobrenome do aluno!")
                    .HasMaxLen(LastName, 20,"Sobrenome", "O sobrenome não pode ter mais que 20 caracteres!")
                    .HasMinLen(PhoneNumber, 8, "Telefone", "Informe um telefone válido contendo apenas numeros!")
                    .HasMaxLen(PhoneNumber, 12,"Telefone", "Informe um telefone válido contendo apenas numeros!")
                    .IsNotNull(BirthDate, "Data de nascimento", "Informe a data de nascimento do aluno!")
                    .IsNotNull(StartDate, "Data de Início", "Informe a data da matrícula do aluno na instituição!")
                    .IsNotNullOrEmpty(Status.ToString(), "Status", "Informe se o aluno está ou não ativo na instituição!")
                    .IsNotEmpty(CourseId, "Código do Curso", "Informe o código do curso em que o aluno será matriculado!")
            );
        }
    }
}
using System;

namespace EpsSchool.Domain.Dtos
{
    public class StudentReportDto
    {
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

    }
}
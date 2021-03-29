using System;

namespace EpsSchool.Domain.Dtos
{
    /// <summary>
    /// Este é o DTO para efetuar o registro de um Aluno no banco de dados
    /// </summary>
    public class StudentRegisterDto
    {
        /// <summary>
        /// Código identificador e chave do Banco.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Código identificador para outras atividades da instituição.
        /// </summary>
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
        public string phoneNumber { get; set; }
        /// <summary>
        /// Data em que o aluno nasceu.
        /// </summary>
        public DateTime Birthdate { get; set; }
        /// <summary>
        /// Data em que o aluno foi matrículado na instituição.
        /// </summary>
        public DateTime StartDate { get; set; } = DateTime.Now;
        /// <summary>
        /// Data em que o aluno cancelou sua matrícula.
        /// </summary>
        public DateTime? EndDAte { get; set; } = null;
        /// <summary>
        /// Informa se o aluno está ativo ou não na instuição.
        /// </summary>
        public bool Status { get; set; } = true;
    }
}
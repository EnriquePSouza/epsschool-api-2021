using System;

namespace EpsSchool.Domain.Dtos
{
    /// <summary>
    /// Este é o DTO para efetuar o registro de um Professor no banco de dados
    /// </summary>
    public class TeacherRegisterDto
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
        /// Primeiro nome do professor.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Segundo nome do professor.
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Telefone do professor.
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Data em que o professor começou a dar aulas na instituição.
        /// </summary>
        public DateTime StartDate { get; set; } = DateTime.Now;
        /// <summary>
        /// Data em que o professor parou de dar aulas na instituição.
        /// </summary>
        public DateTime? EndDate { get; set; } = null;
        /// <summary>
        /// Informa se o professor está ativo ou naõ na instituição.
        /// </summary>
        public bool Status { get; set; } = true;
    }
}
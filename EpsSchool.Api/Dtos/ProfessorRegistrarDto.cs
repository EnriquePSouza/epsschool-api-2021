using System;

namespace EpsSchool.Api.Dtos
{
    /// <summary>
    /// Este é o DTO para efetuar o registro de um Professor no banco de dados
    /// </summary>
    public class ProfessorRegistrarDto
    {
        /// <summary>
        /// Código identificador e chave do Banco.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Código identificador para outras atividades da instituição.
        /// </summary>
        public int Registro { get; set; }
        /// <summary>
        /// Primeiro nome do professor.
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Segundo nome do professor.
        /// </summary>
        public string Sobrenome { get; set; }
        /// <summary>
        /// Telefone do professor.
        /// </summary>
        public string Telefone { get; set; }
        /// <summary>
        /// Data em que o professor começou a dar aulas na instituição.
        /// </summary>
        public DateTime DataInicio { get; set; } = DateTime.Now;
        /// <summary>
        /// Data em que o professor parou de dar aulas na instituição.
        /// </summary>
        public DateTime? DataFim { get; set; } = null;
        /// <summary>
        /// Informa se o professor está ativo ou naõ na instituição.
        /// </summary>
        public bool Ativo { get; set; } = true;
    }
}
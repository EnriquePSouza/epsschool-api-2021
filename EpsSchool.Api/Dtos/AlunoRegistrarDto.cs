using System;

namespace EpsSchool.Api.Dtos
{
    /// <summary>
    /// Este e o DTO para efetuar o registro de um Aluno no banco de dados
    /// </summary>
    public class AlunoRegistrarDto
    {
        /// <summary>
        /// Codigo identificador e chave do Banco.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Código identificador para outras atividades da instituição.
        /// </summary>
        public int Matricula { get; set; }
        /// <summary>
        /// Primeiro nome do aluno.
        /// </summary>
        /// <value></value>
        public string Nome { get; set; }
        /// <summary>
        /// Segundo nome do aluno.
        /// </summary>
        /// <value></value>
        public string Sobrenome { get; set; }
        /// <summary>
        /// Telefone do aluno.
        /// </summary>
        public string Telefone { get; set; }
        /// <summary>
        /// Data em que o aluno nasceu.
        /// </summary>
        public DateTime DataNascimento { get; set; }
        /// <summary>
        /// Data em que o aluno foi matrículado na instituição.
        /// </summary>
        public DateTime DataInicio { get; set; } = DateTime.Now;
        /// <summary>
        /// Data em que o aluno cancelou sua matrícula.
        /// </summary>
        public DateTime? DataFim { get; set; } = null;
        /// <summary>
        /// Informa se o aluno está ativo ou não na instuição.
        /// </summary>
        public bool Ativo { get; set; } = true;
    }
}
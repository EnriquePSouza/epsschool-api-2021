using System.Collections.Generic;
using System.Threading.Tasks;
using EpsSchool.Domain.Repositories;
using EpsSchool.Domain.Dtos;
using EpsSchool.Domain.Helpers;
using EpsSchool.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using EpsSchool.Domain.Handlers;
using AutoMapper;
using EpsSchool.Domain.Commands;
using EpsSchool.Shared.Commands;

namespace EpsSchool.Api.Controllers
{
    /// <summary>
    /// Versão 1 do controlador de Alunos.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class StudentController : ControllerBase
    {
        /// <summary>
        /// Método responsável por retornar todos os Alunos de Forma Assíncrona.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<PageList<Student>>> Get(
            [FromQuery] PageParams pageParams,
            [FromServices] IStudentRepository repo)
        {
            var students = await repo.GetAllAsync(pageParams, true);

            Response.AddPagination(students.CurrentPage, students.PageSize, students.TotalCount, students.TotalPages);

            return students;
        }

        /// <summary>
        /// Método responsável por retornar um Aluno ao informar o seu id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Student GetById(int id,
            [FromServices] IStudentRepository repo)
        {
            return repo.GetById(id, false);
        }

        /// <summary>
        /// Método responsável por inserir as informações de um Aluno no banco de dados.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public GenericCommandResult Create(
            [FromBody] CreateStudentCommand command,
            [FromServices] StudentHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        /// <summary>
        /// Método responsável por atualizar as informações de um Aluno no banco de dados.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public GenericCommandResult Update(
            [FromServices] StudentHandler handler,
            int id,
            [FromBody] CreateStudentCommand command)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        /// <summary>
        /// Método responsável por registrar se um aluno está ou não ativado na Instituição.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("changeStatus")]
        public GenericCommandResult ChangeStatus(
            [FromBody] ChangeStudentStatusCommand command,
            [FromServices] StudentHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        /// <summary>
        /// Método responsável por remover as informações de um Aluno do banco de dados.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete([FromServices]IStudentRepository repo, int id)
        {
            var student = repo.GetById(id);
            if (student == null) return BadRequest(new { message = "Aluno não encontrado!" });

            repo.Delete(student);

            return Ok(new { message = "Aluno detetado." });
        }

    }
}
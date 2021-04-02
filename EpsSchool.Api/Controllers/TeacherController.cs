using System.Collections.Generic;
using AutoMapper;
using EpsSchool.Domain.Repositories;
using EpsSchool.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EpsSchool.Domain.Handlers;
using EpsSchool.Domain.Commands;
using EpsSchool.Shared.Commands;

namespace EpsSchool.Api.Controllers
{
    /// <summary>
    /// Versão 1 do controlador de Professores.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TeacherController : ControllerBase
    {
        /// <summary>
        /// Método responsável por retornar todos os Professores.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Teacher>>> Get(
            [FromServices] ITeacherRepository repo)
        {
            return await repo.GetAll(true);
        }

        /// <summary>
        /// Método responsável por retornar um Professor ao informar o seu id de um Aluno.
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        [HttpGet("bystudent/{studentId}")]
        public async Task<ActionResult<List<Teacher>>> GetByStudentId(
            [FromServices] ITeacherRepository repo, int studentId)
        {
            return await repo.GetByStudentId(studentId, true);
        }

        /// <summary>
        /// Método responsável por retornar um Professor ao informar o seu id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Teacher GetById(int id,
            [FromServices] ITeacherRepository repo)
        {
            return repo.GetById(id, true);
        }

        /// <summary>
        /// Método responsável por inserir as informações de um Professor no banco de dados.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public GenericCommandResult Create(
            [FromBody] CreateTeacherCommand command,
            [FromServices] TeacherHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        /// <summary>
        /// Método responsável por atualizar as informações de um Professor no banco de dados.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public GenericCommandResult Update(
            [FromServices] TeacherHandler handler,
            int id,
            [FromBody] UpdateTeacherCommand command)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        /// <summary>
        /// Método responsável por remover as informações de um Professor do banco de dados.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete([FromServices] ITeacherRepository repo, int id)
        {
            var teacher = repo.GetById(id);
            if (teacher == null) return BadRequest(new { message = "Professor não encontrado!" });

            repo.Delete(teacher);

            return Ok(new { message = "Professor detetado." });
        }

    }
}
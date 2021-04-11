using System.Collections.Generic;
using AutoMapper;
using EpsSchool.Domain.Repositories;
using EpsSchool.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EpsSchool.Domain.Handlers;
using EpsSchool.Domain.Commands;
using EpsSchool.Shared.Commands;
using System;
using EpsSchool.Domain.Dtos;

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
        private readonly IMapper _mapper;
        public TeacherController(IMapper mapper)
        {
            _mapper = mapper;
        }
        /// <summary>
        /// Método responsável por retornar todos os Professores.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get(
            [FromServices] ITeacherRepository repo)
        {
            var teachers = await repo.GetAll(true);

            var teachersResult = _mapper.Map<IEnumerable<TeacherDto>>(teachers);

            return Ok(teachersResult);
        }

        /// <summary>
        /// Método responsável por retornar um Professor ao informar o seu id de um Aluno.
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        [HttpGet("byStudent/{studentId}")]
        public async Task<ActionResult<List<Teacher>>> GetByStudentId(
            [FromServices] ITeacherRepository repo, Guid studentId)
        {
            var teachers = await repo.GetByStudentId(studentId, true);

            var teachersResult = _mapper.Map<IEnumerable<TeacherDto>>(teachers);

            return Ok(teachersResult);
        }

        /// <summary>
        /// Método responsável por retornar um Professor ao informar o seu id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id,
            [FromServices] ITeacherRepository repo)
        {
            var teacher = await repo.GetById(id, true);

            var teachersResult = _mapper.Map<TeacherDto>(teacher);

            return Ok(teachersResult);
        }

        /// <summary>
        /// Método responsável por inserir as informações de um Professor no banco de dados.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<GenericCommandResult> Create(
            [FromBody] CreateTeacherCommand command,
            [FromServices] TeacherHandler handler)
        {
            return (GenericCommandResult) await handler.Handle(command);
        }

        /// <summary>
        /// Método responsável por atualizar as informações de um Professor no banco de dados.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<GenericCommandResult> Update(
            [FromServices] TeacherHandler handler,
            int id,
            [FromBody] UpdateTeacherCommand command)
        {
            GenericCommandResult teacherResult;
            ChangeTeacherStatusCommand changeStatus;

                teacherResult = (GenericCommandResult) await handler.Handle(command); 
                if(teacherResult.Success.Equals(true))
                {
                    changeStatus = new ChangeTeacherStatusCommand(command.Id, command.Status);
                    teacherResult = (GenericCommandResult) await handler.Handle(changeStatus);
                } 

            return teacherResult;
        }

        /// <summary>
        /// Método responsável por remover as informações de um Professor do banco de dados.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromServices] ITeacherRepository repo, Guid id)
        {
            var teacher = await repo.GetById(id);
            if (teacher == null) return BadRequest(new { message = "Professor não encontrado!" });

            repo.Delete(teacher);
            await repo.SaveAsync();

            return Ok(new { message = "Professor detetado." });
        }

    }
}
using System.Threading.Tasks;
using EpsSchool.Domain.Repositories;
using EpsSchool.Domain.Helpers;
using EpsSchool.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using EpsSchool.Domain.Handlers;
using EpsSchool.Domain.Commands;
using EpsSchool.Shared.Commands;
using System.Collections.Generic;
using AutoMapper;

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
        private readonly IMapper _mapper;
        public StudentController(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Método responsável por retornar todos os Alunos de Forma Assíncrona.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Get(
            [FromQuery] PageParams pageParams,
            [FromServices] IStudentRepository repo)
        {
            var students = await repo.GetAllAsync(pageParams, true);
            
            var studentsResult = _mapper.Map<IEnumerable<StudentCommand>>(students);

            Response.AddPagination(students.CurrentPage, students.PageSize, students.TotalCount, students.TotalPages);

            return Ok(studentsResult);
        }

        /// <summary>
        /// Método responsável por retornar um Aluno ao informar o seu Curso.
        /// </summary>
        /// <returns></returns>
        [HttpGet("byCourse/{id}")]
        public async Task<IActionResult> GetByCourseId([FromServices] IStudentRepository repo, int id)
        {
            var students = await repo.GetAllByCourseIdAsync(id, false);
            var studentsResult = _mapper.Map<IEnumerable<CreateStudentCommand>>(students);
            return Ok(studentsResult);
        }

        /// <summary>
        /// Método responsável por retornar um Aluno ao informar o seu id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id,
            [FromServices] IStudentRepository repo)
        {
            var students = await repo.GetById(id, false);
            var studentsResult = _mapper.Map<CreateStudentCommand>(students);
            
            return Ok(studentsResult);
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
            return (GenericCommandResult)handler.Handle(command); // TODO - Change the method to async and resolve the task.
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
            [FromBody] UpdateStudentCommand command)
        {
            return (GenericCommandResult)handler.Handle(command); // TODO - Change the method to async and resolve the task.
        }

        /// <summary>
        /// Método responsável por registrar se um aluno está ou não ativado na Instituição.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("changeStatus")]
        public GenericCommandResult ChangeStatus(
            [FromBody] ChangeStudentStatusCommand command,
            [FromServices] StudentHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command); // TODO - Change the method to async and resolve the task.
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

            repo.Delete(student.Result); // TODO - Change the method to async and resolve the task.

            return Ok(new { message = "Aluno detetado." });
        }

    }
}
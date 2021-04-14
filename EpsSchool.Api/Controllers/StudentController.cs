using System.Threading.Tasks;
using EpsSchool.Domain.Repositories;
using EpsSchool.Domain.Helpers;
using Microsoft.AspNetCore.Mvc;
using EpsSchool.Domain.Handlers;
using EpsSchool.Domain.Commands;
using EpsSchool.Shared.Commands;
using System.Collections.Generic;
using AutoMapper;
using System;
using EpsSchool.Domain.Dtos;

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
        public async Task<IActionResult> GetAll(
            [FromQuery] PageParams pageParams,
            [FromServices] IStudentRepository repo)
        {
            try
            {
                var students = await repo.GetAllAsync(pageParams, true);

                var studentsResult = _mapper.Map<IEnumerable<StudentDto>>(students);

                Response.AddPagination(students.CurrentPage, students.PageSize,
                                        students.TotalCount, students.TotalPages);

                return Ok(studentsResult);
            }
            catch (Exception ex)
            {
                var errorDetails = $"Algo de errado aconteceu ao axecutar a ação GetAll: {ex.Message}";
                var studentsResult = new GenericCommandResult(false,
                                        "Erro interno do servidor.", errorDetails);
                return StatusCode(500, studentsResult);
            }
        }

        /// <summary>
        /// Método responsável por retornar um Aluno ao informar o seu Curso.
        /// </summary>
        /// <returns></returns>
        [HttpGet("byCourse/{id}")]
        public async Task<IActionResult> GetByCourseId([FromServices] IStudentRepository repo, Guid id)
        {
            try
            {
                var students = await repo.GetAllByCourseIdAsync(id, false);
                var studentsResult = _mapper.Map<IEnumerable<CreateStudentCommand>>(students);
                return Ok(studentsResult);
            }
            catch (Exception ex)
            {
                var errorDetails = $"Algo de errado aconteceu ao axecutar a ação GetByCourseId: {ex.Message}";
                var studentsResult = new GenericCommandResult(false,
                                        "Erro interno do servidor.", errorDetails);
                return StatusCode(500, studentsResult);
            }
        }

        /// <summary>
        /// Método responsável por retornar um Aluno ao informar o seu id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id,
            [FromServices] IStudentRepository repo)
        {
            try
            {
                var students = await repo.GetById(id, false);
                var studentResult = _mapper.Map<CreateStudentCommand>(students);
                return Ok(studentResult);
            }
            catch (Exception ex)
            {
                var errorDetails = $"Algo de errado aconteceu ao axecutar a ação GetById: {ex.Message}";
                var studentResult = new GenericCommandResult(false,
                                        "Erro interno do servidor.", errorDetails);
                return StatusCode(500, studentResult);
            }
        }

        /// <summary>
        /// Método responsável por inserir as informações de um Aluno no banco de dados.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateStudentCommand command,
            [FromServices] StudentHandler handler)
        {
            try
            {
                var studentResult = (GenericCommandResult)await handler.Handle(command);
                return Ok(studentResult);
            }
            catch (Exception ex)
            {
                var errorDetails = $"Algo de errado aconteceu ao axecutar a ação Create: {ex.Message}";
                var studentResult = new GenericCommandResult(false,
                                        "Erro interno do servidor.", errorDetails);
                return StatusCode(500, studentResult);
            }
        }

        /// <summary>
        /// Método responsável por atualizar as informações de um Aluno no banco de dados.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            [FromServices] StudentHandler handler,
            int id,
            [FromBody] UpdateStudentCommand command)
        {
            try
            {
                var studentResult = (GenericCommandResult)await handler.Handle(command);
                if (studentResult.Success.Equals(true))
                {
                    var changeStatus = new ChangeStudentStatusCommand(command.Id, command.Status);
                    studentResult = (GenericCommandResult)await handler.Handle(changeStatus);
                }

                return Ok(studentResult);
            }
            catch (Exception ex)
            {
                var errorDetails = $"Algo de errado aconteceu ao axecutar a ação Update: {ex.Message}";
                var studentResult = new GenericCommandResult(false,
                                        "Erro interno do servidor.", errorDetails);
                return StatusCode(500, studentResult);
            }
        }

        /// <summary>
        /// Método responsável por registrar se um aluno está ou não ativado na Instituição.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("changeStatus")]
        public async Task<IActionResult> ChangeStatus(
            [FromBody] ChangeStudentStatusCommand command,
            [FromServices] StudentHandler handler)
        {
            try
            {
                var studentResult = (GenericCommandResult)await handler.Handle(command);
                return Ok(studentResult);
            }
            catch (Exception ex)
            {
                var errorDetails = $"Algo de errado aconteceu ao axecutar a ação ChangeStatus: {ex.Message}";
                var studentResult = new GenericCommandResult(false,
                                        "Erro interno do servidor.", errorDetails);
                return StatusCode(500, studentResult);
            }
        }

        /// <summary>
        /// Método responsável por remover as informações de um Aluno do banco de dados.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(
            [FromServices] IStudentRepository repoStudent,
            [FromServices] IStudentCourseSubjectRepository repoScs, Guid id)
        {
            try
            {
                var student = await repoStudent.GetById(id);
                if (student == null)
                    return NotFound(new GenericCommandResult(false,
                                        "Aluno não encontrado!", "StudentId: " + id));

                var studentCoursesSubjects = await repoScs.GetAllByStudentIdAsync(id);
                if (studentCoursesSubjects == null)
                    return NotFound(new GenericCommandResult(false,
                                        "O Aluno não está matriculado em nenhum curso!",
                                        "StudentId: " + id));

                // Deletes the student course enrollment.
                foreach (var studentCourseSubject in studentCoursesSubjects)
                {
                    repoScs.Delete(studentCourseSubject);
                    await repoScs.SaveAsync();
                }

                repoStudent.Delete(student);
                await repoStudent.SaveAsync();

                var deletedStudent = _mapper.Map<CreateStudentCommand>(student);
                var studentResult = new GenericCommandResult(false,
                                        "Aluno detetado!", deletedStudent);

                return Ok(studentResult);
            }
            catch (Exception ex)
            {
                var errorDetails = $"Algo de errado aconteceu ao axecutar a ação Delete: {ex.Message}";
                var studentResult = new GenericCommandResult(false,
                                        "Erro interno do servidor.", errorDetails);
                return StatusCode(500, studentResult);
            }
        }

    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EpsSchool.Domain.Repositories;
using EpsSchool.Domain.Dtos;
using EpsSchool.Domain.Helpers;
using EpsSchool.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

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
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        /// <summary>
        /// Método construtor do controlador de Alunos.
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="mapper"></param>
        public StudentController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <summary>
        /// Método responsável por retornar todos os Alunos de Forma Assíncrona.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PageParams pageParams)
        {
            var students = await _repo.GetAllStudentsAsync(pageParams, true);

            var studentsResult = _mapper.Map<IEnumerable<StudentDto>>(students);

            Response.AddPagination(students.CurrentPage, students.PageSize, students.TotalCount, students.TotalPages);

            return Ok(studentsResult);
        }

        /// <summary>
        /// Método responsável por retornar um Aluno ao informar o seu id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _repo.GetStudentById(id, false);
            if (student == null) return BadRequest("O Aluno não foi encontrado");

            var studentDto = _mapper.Map<StudentRegisterDto>(student);

            return Ok(studentDto);
        }

        /// <summary>
        /// Método responsável por inserir as informações de um Aluno no banco de dados.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// FEITO - Pronto para aluno ---------------------------------------------
        [HttpPost]
        public IActionResult Post(StudentRegisterDto model)
        {
            var student = _mapper.Map<Student>(model);


            _repo.Add(student);
            if (_repo.SaveChanges())
            {
                return Created($"/api/student/{model.Id}", _mapper.Map<StudentDto>(student));
            }

            return BadRequest("Aluno não cadastrado!");

        }

        /// <summary>
        /// Método responsável por atualizar as informações de um Aluno no banco de dados.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        /// FEITO - Pronto para aluno ---------------------------------------------
        [HttpPut("{id}")]
        public IActionResult Put(int id, StudentRegisterDto model)
        {
            var student = _repo.GetStudentById(id);
            if (student == null) return BadRequest("Aluno não encontrado!");

            _mapper.Map(model, student);

            _repo.Update(student);
            if (_repo.SaveChanges())
            {
                return Created($"/api/student/{model.Id}", _mapper.Map<StudentDto>(student));
            }

            return BadRequest("Aluno não atualizado!");
        }

        /// <summary>
        /// Método responsável por atualizar todas ou algumas das informações de um Aluno no banco de dados.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        /// FEITO - Pronto para aluno ---------------------------------------------
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, StudentPatchDto model)
        {
            var student = _repo.GetStudentById(id);
            if (student == null) return BadRequest("Aluno não encontrado!");

            _mapper.Map(model, student);

            _repo.Update(student);
            if (_repo.SaveChanges())
            {
                return Created($"/api/student/{model.Id}", _mapper.Map<StudentPatchDto>(student));
            }

            return BadRequest("Aluno não atualizado!");
        }

        /// <summary>
        /// Método responsável por registrar se um aluno está ou não ativado na Instituição.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="changeStatus"></param>
        /// <returns></returns>
        /// FEITO - Pronto para aluno ---------------------------------------------
        [HttpPatch("{id}/changeStatus")]
        public IActionResult ChangeStatus(int id, ChangeStatusDto changeStatus)
        {
            var student = _repo.GetStudentById(id);
            if (student == null) return BadRequest("Aluno não encontrado!");

            if (changeStatus.Status)
            {
                student.IsActive();
            }
            else
            {
                student.IsInactive();
            }

            _repo.Update(student);
            if (_repo.SaveChanges())
            {
                var msn = student.Status ? "ativado" : "desativado";
                return Ok(new { message = $"Aluno {msn} com sucesso!" });
            }

            return BadRequest("Aluno não atualizado!");
        }

        /// <summary>
        /// Método responsável por remover as informações de um Aluno do banco de dados.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _repo.GetStudentById(id);
            if (student == null) return BadRequest("Aluno não encontrado!");

            _repo.Remove(student);
            if (_repo.SaveChanges())
            {
                return Ok("Aluno detetado.");
            }

            return BadRequest("O Aluno não foi deletado!");
        }

    }
}
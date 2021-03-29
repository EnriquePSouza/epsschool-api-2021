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

            var studentsResult = _mapper.Map<IEnumerable<AlunoDto>>(students);

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

            var studentDto = _mapper.Map<AlunoRegistrarDto>(student);

            return Ok(studentDto);
        }

        /// <summary>
        /// Método responsável por inserir as informações de um Aluno no banco de dados.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(AlunoRegistrarDto model)
        {
            var student = _mapper.Map<Student>(model);


            _repo.Add(student);
            if (_repo.SaveChanges())
            {
                return Created($"/api/student/{model.Id}", _mapper.Map<AlunoDto>(student));
            }

            return BadRequest("Aluno não cadastrado!");

        }

        /// <summary>
        /// Método responsável por atualizar as informações de um Aluno no banco de dados.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, AlunoRegistrarDto model)
        {
            var student = _repo.GetStudentById(id);
            if (student == null) return BadRequest("Aluno não encontrado!");

            _mapper.Map(model, student);

            _repo.Update(student);
            if (_repo.SaveChanges())
            {
                return Created($"/api/student/{model.Id}", _mapper.Map<AlunoDto>(student));
            }

            return BadRequest("Aluno não atualizado!");
        }

        /// <summary>
        /// Método responsável por atualizar todas ou algumas das informações de um Aluno no banco de dados.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, AlunoPatchDto model)
        {
            var student = _repo.GetStudentById(id);
            if (student == null) return BadRequest("Aluno não encontrado!");

            _mapper.Map(model, student);

            _repo.Update(student);
            if (_repo.SaveChanges())
            {
                return Created($"/api/student/{model.Id}", _mapper.Map<AlunoPatchDto>(student));
            }

            return BadRequest("Aluno não atualizado!");
        }

        /// <summary>
        /// Método responsável por registrar se um aluno está ou não ativado na Instituição.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="trocaEstado"></param>
        /// <returns></returns>
        [HttpPatch("{id}/trocarEstado")]
        public IActionResult trocarEstado(int id, TrocaEstadoDto trocaEstado)
        {
            var student = _repo.GetStudentById(id);
            if (student == null) return BadRequest("Aluno não encontrado!");

            if (trocaEstado.Estado)
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
                var msn = student.Ativo ? "ativado" : "desativado";
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
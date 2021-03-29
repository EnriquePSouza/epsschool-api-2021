using System.Collections.Generic;
using AutoMapper;
using EpsSchool.Domain.Repositories;
using EpsSchool.Domain.Dtos;
using EpsSchool.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

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
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        /// <summary>
        /// Método construtor do controlador de Professores.
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="mapper"></param>
        public TeacherController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <summary>
        /// Método responsável por retornar todos os Professores.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var teachers = _repo.GetAllTeachers(true);

            return Ok(_mapper.Map<IEnumerable<ProfessorDto>>(teachers));
        }

        /// <summary>
        /// Método responsável por retornar um Professor ao informar o seu id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var teachers = _repo.GetTeacherById(id, true);
            if (teachers == null) return BadRequest("O Professor não foi encontrado");

            var teachersDto = _mapper.Map<ProfessorDto>(teachers);

            return Ok(teachersDto);
        }

        /// <summary>
        /// Método responsável por retornar um Professor ao informar o seu id de um Aluno.
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        [HttpGet("bystudent/{studentId}")]
        public IActionResult GetByStudentId(int studentId)
        {
            var teachers = _repo.GetTeachersByStudentId(studentId, true);
            if (teachers == null) return BadRequest("Professores não encontrados"); 

            return Ok(_mapper.Map<IEnumerable<ProfessorDto>>(teachers));
        }

        /// <summary>
        /// Método responsável por inserir as informações de um Professor no banco de dados.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(ProfessorRegistrarDto model)
        {
            var teacher = _mapper.Map<Teacher>(model);

            _repo.Add(teacher);
            if (_repo.SaveChanges())
            {
                return Created($"/api/teacher/{model.Id}", _mapper.Map<ProfessorDto>(teacher));
            }

            return BadRequest("Professor não cadastrado!");
        }

        /// <summary>
        /// Método responsável por atualizar as informações de um Professor no banco de dados.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, ProfessorRegistrarDto model)
        {
            var teacher = _repo.GetTeacherById(id);
            if (teacher == null) return BadRequest("Professor não encontrado!");

            _mapper.Map(model, teacher);

            _repo.Update(teacher);
            if (_repo.SaveChanges())
            {
                return Created($"/api/teacher/{model.Id}", _mapper.Map<ProfessorDto>(teacher));
            }

            return BadRequest("Professor não atualizado!");
        }

        /// <summary>
        /// Método responsável por atualizar todas ou algumas das informações de um Professor no banco de dados.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, ProfessorRegistrarDto model)
        {
            var teacher = _repo.GetTeacherById(id);
            if (teacher == null) return BadRequest("Professor não encontrado!");

            _mapper.Map(model, teacher);

            _repo.Update(teacher);
            if (_repo.SaveChanges())
            {
                return Created($"/api/teacher/{model.Id}", _mapper.Map<ProfessorDto>(teacher));
            }

            return BadRequest("Professor não atualizado!");
        }

        /// <summary>
        /// Método responsável por remover as informações de um Professor do banco de dados.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var teacher = _repo.GetTeacherById(id);
            if (teacher == null) return BadRequest("Professor não encontrado!");

            _repo.Remove(teacher);
            if (_repo.SaveChanges())
            {
                return Ok("Professor deletado.");
            }

            return BadRequest("O Professor não foi deletado!");
        }

    }
}
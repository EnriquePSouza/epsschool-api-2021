using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EpsSchool.Api.Data;
using EpsSchool.Api.Dtos;
using EpsSchool.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EpsSchool.Api.Controllers
{
    /// <summary>
    /// Versão 1 do controlador de Professores.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        /// <summary>
        /// Método construtor do controlador de Professores.
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="mapper"></param>
        public ProfessorController(IRepository repo, IMapper mapper)
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
            var professores = _repo.GetAllProfessores(true);

            return Ok(_mapper.Map<IEnumerable<ProfessorDto>>(professores));
        }

        /// <summary>
        /// Método responsável por retornar um Professor ao informar o seu id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _repo.GetProfessorById(id, true);
            if (professor == null) return BadRequest("O Professor não foi encontrado");

            var professorDto = _mapper.Map<ProfessorDto>(professor);

            return Ok(professorDto);
        }

        /// <summary>
        /// Método responsável por retornar um Professor ao informar o seu id de um Aluno.
        /// </summary>
        /// <param name="alunoId"></param>
        /// <returns></returns>
        [HttpGet("byaluno/{alunoId}")]
        public IActionResult GetByAlunoId(int alunoId)
        {
            var professores = _repo.GetProfessoresByAlunoId(alunoId, true);
            if (professores == null) return BadRequest("Professores não encontrados"); 

            return Ok(_mapper.Map<IEnumerable<ProfessorDto>>(professores));
        }

        /// <summary>
        /// Método responsável por inserir as informações de um Professor no banco de dados.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(ProfessorRegistrarDto model)
        {
            var professor = _mapper.Map<Professor>(model);

            _repo.Add(professor);
            if (_repo.SaveChanges())
            {
                return Created($"/api/professor/{model.Id}", _mapper.Map<ProfessorDto>(professor));
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
            var professor = _repo.GetProfessorById(id);
            if (professor == null) return BadRequest("Professor não encontrado!");

            _mapper.Map(model, professor);

            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Created($"/api/professor/{model.Id}", _mapper.Map<ProfessorDto>(professor));
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
            var professor = _repo.GetProfessorById(id);
            if (professor == null) return BadRequest("Professor não encontrado!");

            _mapper.Map(model, professor);

            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Created($"/api/professor/{model.Id}", _mapper.Map<ProfessorDto>(professor));
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
            var professor = _repo.GetProfessorById(id);
            if (professor == null) return BadRequest("Professor não encontrado!");

            _repo.Remove(professor);
            if (_repo.SaveChanges())
            {
                return Ok("Professor deletado.");
            }

            return BadRequest("O Professor não foi deletado!");
        }

    }
}
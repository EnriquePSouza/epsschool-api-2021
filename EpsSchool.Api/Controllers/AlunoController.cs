using System.Collections.Generic;
using System.Linq;
using EpsSchool.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace EpsSchool.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>() {
            new Aluno() {
                Id = 1,
                Nome = "Marcos",
                Sobrenome = "Souza",
                Telefone = "1231546"
            },
            new Aluno() {
                Id = 2,
                Nome = "Alexandre",
                Sobrenome = "Silva",
                Telefone = "1231546"
            },
            new Aluno() {
                Id = 3,
                Nome = "Fernanda",
                Sobrenome = "Dantas",
                Telefone = "1231546"
            }
        };

        public AlunoController() { }
        // GET api/aluno
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }

        // GetById api/aluno/byId/id
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(aluno => aluno.Id == id);
            if (aluno == null) return BadRequest("O Aluno não foi encontrado");

            return Ok(aluno);
        }

        // GetByName api/aluno/ByName
        [HttpGet("byName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = Alunos.FirstOrDefault(a =>
                a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome)
            );
            if (aluno == null) return BadRequest("O Aluno não foi encontrado");

            return Ok(aluno);
        }

        // Post
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }

        // Put
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        // Patch
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        // Delete
        [HttpPut("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }

    }
}
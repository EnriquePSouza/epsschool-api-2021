using System.Collections.Generic;
using System.Linq;
using EpsSchool.Api.Data;
using EpsSchool.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EpsSchool.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly SchoolContext _context;

        public ProfessorController(SchoolContext context)
        {
            _context = context;
        }

        // GET api/professor
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professores);
        }

        // GetById api/professor/byId/id
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _context.Professores.FirstOrDefault(a => a.Id == id);
            if (professor == null) return BadRequest("O Professor não foi encontrado");

            return Ok(professor);
        }

        // GetByName api/professor/ByName
        [HttpGet("byName")]
        public IActionResult GetByName(string nome)
        {
            var professor = _context.Professores.FirstOrDefault(a => a.Nome.Contains(nome));
            if (professor == null) return BadRequest("O Professor não foi encontrado");

            return Ok(professor);
        }

        // Post
        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _context.Add(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        // Put
        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if (prof == null) return BadRequest("Professor não Encontrado!");

            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        // Patch
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if (prof == null) return BadRequest("Professor não Encontrado!");

            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        // Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _context.Professores.FirstOrDefault(a => a.Id == id);
            if (professor == null) return BadRequest("Professor não Encontrado!");

            _context.Remove(professor);
            _context.SaveChanges();
            return Ok();
        }

    }
}
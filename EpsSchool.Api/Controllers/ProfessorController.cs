using Microsoft.AspNetCore.Mvc;

namespace EpsSchool.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        public ProfessorController(){ }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Controller Professor - Teste Inicial!");
        }
        
    }
}
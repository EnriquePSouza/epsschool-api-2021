using Microsoft.AspNetCore.Mvc;

namespace EpsSchool.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public AlunoController(){ }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Controller Aluno - Teste Inicial!");
        }
        
    }
}
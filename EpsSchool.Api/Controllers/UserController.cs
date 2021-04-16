using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using EpsSchool.Infra.Contexts;
using EpsSchool.Domain.Entities;

namespace EpsSchool.Api.Controllers
{
    /// <summary>
    /// Versão 1 do controlador de Acesso de Usuários.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserController : Controller
    {
        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public async Task<ActionResult<User>> Post(
            [FromServices] SchoolContext context,
            [FromBody] User user)
        {
            if (!ModelState.IsValid) // Change to command and make one handler
                return BadRequest(ModelState);

            try
            {
                context.Users.Add(user);
                await context.SaveChangesAsync();

                return user;
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possivel criar um usuário!" });
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate(
            [FromServices] SchoolContext context,
            [FromBody] User user)
        {
            // TODO > Make the authenticate method.
            return await Task.Factory.StartNew(() => { return user; });
        }
    }
}
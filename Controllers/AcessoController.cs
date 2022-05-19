using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace autenticacao.Controllers
{

    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class AcessoController : ControllerBase
    {

        [HttpGet]
        [Route("publico")]
        [AllowAnonymous]
        public IActionResult AcessoPublico()
        {

            return Ok("Acesso público de todos os colaboradores");
        }

        [HttpGet]
        [Route("funcionario")]
        [Authorize(Roles = "gerente,funcionario")]
        public IActionResult AcessoFuncionario()
        {
            return Ok($"Bem-vindo {User.Identity.Name}, à pagina de funcionários");
        }

        [HttpGet]
        [Route("gerente")]
        [Authorize(Roles = "gerente")]
        public IActionResult AcessoGerente()
        {
            return Ok("Acesso exclusivo à gerentes");
        }

    }
}
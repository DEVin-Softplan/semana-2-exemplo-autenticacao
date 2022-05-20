using System.Linq;
using autenticacao.Enums;
using autenticacao.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;

namespace autenticacao.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class AcessoController : ControllerBase
    {

        [Route("listar")]
        [Authorize]
        [HttpGet]
        public IActionResult Listar()
            => User.IsInRole(Permissoes.Funcionario.GetDisplayName())
                ? Ok(UserRepository.Obter().Select(x => new {x.Username, x.DescricaoPermissao}))
                : Ok(UserRepository.Obter());


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
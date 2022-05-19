using autenticacao.Dtos;
using autenticacao.Repositories;
using autenticacao.Services;
using Microsoft.AspNetCore.Mvc;

namespace autenticacao.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AutenticacaoController : ControllerBase
    {

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {

            var user = UserRepository.VerificarUsuarioESenha(dto.Username, dto.Password);

            if (user == null) return NotFound();

            var token = TokenService.GenerateToken(user);

            return Ok(new {token});
        }

    }
}
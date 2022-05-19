using autenticacao.Dtos;
using autenticacao.Repositories;
using autenticacao.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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
            var newRefreshToken = TokenService.GenerateRefreshToken();
            TokenService.SaveRefreshToken(user.Username, newRefreshToken);

            return Ok(new
            {
                token,
                newRefreshToken
            });

        }

        [HttpPost]
        [Route("refresh")]
        [AllowAnonymous]
        public ActionResult<dynamic> RefreshToken([FromQuery] string token, [FromQuery] string refreshToken)
        {

            var principal = TokenService.GetPrincipalFromExpiredToken(token);
            var username = principal.Identity.Name;
            var savedRefreshToken = TokenService.GetRefreshToken(username);

            if (savedRefreshToken != refreshToken)
                throw new SecurityTokenException("Invalid refresh token");

            var newToken = TokenService.GenerateToken(principal.Claims);
            var newRefreshToken = TokenService.GenerateRefreshToken();
            TokenService.DeleteRefreshToken(username, refreshToken);
            TokenService.SaveRefreshToken(username, newRefreshToken);

            return new ObjectResult(new
            {
                token = newToken,
                refreshToken = newRefreshToken
                
            });

        }

    }
}
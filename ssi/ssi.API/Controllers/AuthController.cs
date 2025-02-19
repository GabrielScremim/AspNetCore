using Microsoft.AspNetCore.Mvc;
using ssi.API.DTOs;
using ssi.API.Services;

namespace ssi.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            var token = await _authService.LoginAsync(loginDTO);
            if (token == null)
                return Unauthorized(new { mensagem = "Credenciais inválidas" });

            return Ok(new { token });
        }
    }
}

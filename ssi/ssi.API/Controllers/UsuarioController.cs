using Microsoft.AspNetCore.Mvc;
using ssi.API.Interfaces;
using ssi.API.Models;

namespace ssi.API.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuario _usuarioService;

        public UsuarioController(IUsuario usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("cadastro")]
        public async Task<IActionResult> Cadastro([FromBody] Usuario usuario)
        {
            try
            {
                var novoUsuario = await _usuarioService.CadastroUser(
                    usuario.Chapa, usuario.Nome, usuario.Ramal, usuario.Senha);

                return CreatedAtAction(nameof(ObterInfosUser), new { chapa = novoUsuario.Chapa }, novoUsuario);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            return Ok(await _usuarioService.GetAll());
        }

        [HttpGet("{chapa}")]
        public async Task<IActionResult> ObterInfosUser(string chapa)
        {
            var usuario = await _usuarioService.ObterInfosUser(chapa);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }
    }
}

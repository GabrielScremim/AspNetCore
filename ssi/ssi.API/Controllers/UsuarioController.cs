using Microsoft.AspNetCore.Mvc;
using ssi.API.Interfaces;
using ssi.API.Models;

namespace ssi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuario _usuario;

        public UsuarioController(IUsuario usuario)
        {
            _usuario = usuario;
        }
        [HttpGet("GetUsers")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetAll()
        {
            return Ok(await _usuario.GetAll());
        }

        [HttpGet("GetByChapa")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetByChapa(string chapa)
        {
            try
            {
                // Retrieve the list of SSIs for the given user
                var chapaUser = await _usuario.ObterInfosUser(chapa);

                if (chapaUser == null || !chapaUser.Any())
                {
                    return NotFound("Nenhum usuário encontrado para a chapa informada.");
                }

                return Ok(chapaUser); // Return data in JSON format
            }
            catch (Exception ex)
            {
                // Log the exception (you can log it using a logger if needed)
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
    }
}

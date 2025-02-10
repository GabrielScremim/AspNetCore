using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ssi.API.Interfaces;
using ssi.API.Models;

namespace ssi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AcompanharController : Controller
    {
        private readonly IAcompanhar _acompanhar;

        public AcompanharController(IAcompanhar acompanhar)
        {
            _acompanhar = acompanhar;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<Ssi>>> GetSSI()
        {
            return Ok(await _acompanhar.BuscarSSI());
        }

        [HttpGet("ssiUsuario/{chapaUsuario}")]
        public async Task<ActionResult<IEnumerable<Ssi>>> GetSsiUsuario(string chapaUsuario)
        {
            try
            {
                // Retrieve the list of SSIs for the given user
                var ssis = await _acompanhar.BuscarSSIUsuario(chapaUsuario);

                if (ssis == null || !ssis.Any())
                {
                    return NotFound("Nenhum SSI encontrado para o usuário informado.");
                }

                return Ok(ssis); // Return data in JSON format
            }
            catch (Exception ex)
            {
                // Log the exception (you can log it using a logger if needed)
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpGet("ssiUsuarioDate/{chapaUsuario}")]
        public async Task<ActionResult<IEnumerable<Ssi>>> GetSsiUsuarioDate(string chapaUsuario, DateTime dataInicio, DateTime dataFim)
        {
            try
            {
                // Recupera a lista de SSIs para o usuário informado dentro do intervalo de datas
                var ssis = await _acompanhar.BuscarSSUsuarioDate(chapaUsuario, dataInicio, dataFim);

                if (ssis == null || !ssis.Any())
                {
                    return NotFound("Nenhum SSI encontrado para o usuário informado no intervalo de datas.");
                }

                return Ok(ssis); // Retorna os dados no formato JSON
            }
            catch (Exception ex)
            {
                // Loga a exceção (se necessário, use um logger)
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpGet("ssiDate/")]
        public async Task<ActionResult<IEnumerable<Ssi>>> GetSsiDate(DateTime dataInicio, DateTime dataFim)
        {
            try
            {
                // Recupera a lista de SSIs para o usuário informado dentro do intervalo de datas
                var ssis = await _acompanhar.BuscarSSIDate(dataInicio, dataFim);

                if (ssis == null || !ssis.Any())
                {
                    return NotFound("Nenhum SSI encontrado para o intervalo de datas.");
                }

                return Ok(ssis); // Retorna os dados no formato JSON
            }
            catch (Exception ex)
            {
                // Loga a exceção (se necessário, use um logger)
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
    }
}

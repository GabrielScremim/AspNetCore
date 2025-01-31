using Microsoft.AspNetCore.Mvc;
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
    }
}

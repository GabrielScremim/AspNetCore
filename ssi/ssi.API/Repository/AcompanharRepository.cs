using Microsoft.EntityFrameworkCore;
using ssi.API.Interfaces;
using ssi.API.Models;

namespace ssi.API.Repository
{
    public class AcompanharRepository : IAcompanhar
    {
        private readonly ssiContext _context;

        public AcompanharRepository(ssiContext context)
        {
            _context = context;
        }

        public Task AtualizarSSI(DateTime dataHoraFormatada, string descricaoServico, int id, int chapaTecnico)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Ssi>> BuscarSSI()
        {
            return await _context.Ssis.ToListAsync();
        }

        public Task<IEnumerable<Ssi>> BuscarSSIDate(DateTime dataInicio, DateTime dataFim)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Ssi>> BuscarSSIUsuario(int chapaUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Ssi>> BuscarSSUsuarioDate(int chapaUsuario, DateTime dataInicio, DateTime dataFim)
        {
            throw new NotImplementedException();
        }
    }
}

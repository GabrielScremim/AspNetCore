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

        public Task AtualizarSSI(DateTime dataHoraFormatada, string descricaoServico, int id, string chapaTecnico)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Ssi>> BuscarSSI()
        {
            return await _context.Ssis.ToListAsync();
        }

        public async Task<IEnumerable<Ssi>> BuscarSSIDate(DateTime dataInicio, DateTime dataFim)
        {
            return await _context.Ssis.Where(s=> s.DataRegistro >= dataInicio && s.DataFinalizacao <= dataFim).ToListAsync();
        }

        public async Task<IEnumerable<Ssi>> BuscarSSIUsuario(string chapaUsuario)
        {
            return await _context.Ssis.Where(s => s.ChapaSolicitante == chapaUsuario).ToListAsync();
        }

        public async Task<IEnumerable<Ssi>> BuscarSSUsuarioDate(string chapaUsuario, DateTime dataInicio, DateTime dataFim)
        {
            return await _context.Ssis.Where(s => s.ChapaSolicitante == chapaUsuario && s.DataRegistro >= dataInicio && s.DataFinalizacao <= dataFim).ToListAsync();
        }
    }
}

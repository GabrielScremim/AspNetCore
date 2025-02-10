using ssi.API.Models;

namespace ssi.API.Interfaces
{
    public interface IAcompanhar
    {
        Task<IEnumerable<Ssi>> BuscarSSI();
        Task<IEnumerable<Ssi>> BuscarSSIDate(DateTime dataInicio, DateTime dataFim);
        Task<IEnumerable<Ssi>> BuscarSSIUsuario(string chapaUsuario);
        Task<IEnumerable<Ssi>> BuscarSSUsuarioDate(string chapaUsuario, DateTime dataInicio, DateTime dataFim);
        Task AtualizarSSI(DateTime dataHoraFormatada, string descricaoServico, int id, string chapaTecnico);
    }
}

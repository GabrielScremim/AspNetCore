using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using ssi.API.Models;

namespace ssi.API.Interfaces
{
    public interface IAcompanhar
    {
        Task<IEnumerable<Ssi>> BuscarSSI();
        Task<IEnumerable<Ssi>> BuscarSSIDate(DateTime dataInicio, DateTime dataFim);
        Task<IEnumerable<Ssi>> BuscarSSIUsuario(int chapaUsuario);
        Task<IEnumerable<Ssi>> BuscarSSUsuarioDate(int chapaUsuario, DateTime dataInicio, DateTime dataFim);
        Task AtualizarSSI(DateTime dataHoraFormatada, string descricaoServico, int id, int chapaTecnico);
    }
}

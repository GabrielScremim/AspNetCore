using ssi.API.Models;

namespace ssi.API.Interfaces
{
    public interface IUsuario
    {
        Task<IEnumerable<Usuario>> GetAll();
        Task<IEnumerable<Usuario>> ObterInfosUser(string chapa);
        Task<Usuario> CadastroUser(string chapa, string nome, int ramal, string senha);
    }
}

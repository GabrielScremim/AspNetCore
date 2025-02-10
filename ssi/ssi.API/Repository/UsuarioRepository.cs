using Microsoft.EntityFrameworkCore;
using ssi.API.Interfaces;
using ssi.API.Models;

namespace ssi.API.Repository
{
    public class UsuarioRepository : IUsuario
    {
        private readonly ssiContext _context;
        public UsuarioRepository(ssiContext context)
        {
            _context = context;
        }
        public async Task<Usuario> CadastroUser(string chapa, string nome, int ramal, string senha)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<IEnumerable<Usuario>> ObterInfosUser(string chapa)
        {
            return await _context.Usuarios.Where(s => s.Chapa == chapa).ToListAsync();
        }
    }
}

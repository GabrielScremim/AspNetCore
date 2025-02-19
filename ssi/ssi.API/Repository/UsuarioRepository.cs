using Microsoft.EntityFrameworkCore;
using ssi.API.Interfaces;
using ssi.API.Models;
using System.Security.Cryptography;
using System.Text;

namespace ssi.API.Repository
{
    public class UsuarioRepository : IUsuario
    {
        private readonly ssiContext _context;

        public UsuarioRepository(ssiContext context)
        {
            _context = context;
        }

        public async Task<Usuario> CadastroUser(string chapa, string nome, string ramal, string senha)
        {
            // Verifica se o usuário já existe
            if (await _context.Usuarios.AnyAsync(u => u.Chapa == chapa))
            {
                throw new Exception("Usuário já existe.");
            }

            // Criptografa a senha antes de salvar
            string senhaHash = HashSenha(senha);

            var novoUsuario = new Usuario
            {
                Chapa = chapa,
                Nome = nome,
                Ramal = ramal,
                Senha = senhaHash, // Senha já protegida
                TipoUsuario = "usuario", // Defina um padrão
                Mostrar = "1"
            };

            _context.Usuarios.Add(novoUsuario);
            await _context.SaveChangesAsync();

            return novoUsuario;
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<IEnumerable<Usuario>> ObterInfosUser(string chapa)
        {
            return await _context.Usuarios.Where(s => s.Chapa == chapa).ToListAsync();
        }

        // Método para criptografar a senha
        private string HashSenha(string senha)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}

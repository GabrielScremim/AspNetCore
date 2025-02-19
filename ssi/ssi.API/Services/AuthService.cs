using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ssi.API.DTOs;
using ssi.API.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ssi.API.Services
{
    public class AuthService
    {
        private readonly ssiContext _context;
        private readonly IConfiguration _config;

        public AuthService(ssiContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<string> LoginAsync(LoginDTO login)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Chapa == login.Chapa);
            if (usuario == null || usuario.Senha != login.Senha) // Troque por hashing na produção
            {
                return null;
            }

            return GerarToken(usuario);
        }

        private string GerarToken(Usuario usuario)
        {
            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim("Chapa", usuario.Chapa),
                new Claim(ClaimTypes.Role, usuario.TipoUsuario)
            };

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credenciais
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

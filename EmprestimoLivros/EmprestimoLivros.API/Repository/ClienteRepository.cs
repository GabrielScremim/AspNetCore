using EmprestimoLivros.API.Interfaces;
using EmprestimoLivros.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EmprestimoLivros.API.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly emprestimo_livrosContext _context;
        public ClienteRepository(emprestimo_livrosContext context)
        {
            _context = context;
        }
        public void Alterar(Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
        }
        public void Excluir(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _context.Clientes.ToListAsync();
        }

        public void Incluir(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Cliente> SelecionarByPk(int id)
        {
            var cliente = await _context.Clientes.Where(x => x.IdCliente == id).FirstOrDefaultAsync();
            return cliente;
        }
    }
}

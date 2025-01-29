using EmprestimoLivros.API.Interfaces;
using EmprestimoLivros.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoLivros.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet("SelecionarTodos")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return Ok(await _clienteRepository.GetAll());
        }

        [HttpPost("incluirCliente")]
        public async Task<ActionResult> CadastrarCliente(Cliente cliente)
        {
            _clienteRepository.Incluir(cliente);
            if (await _clienteRepository.SaveAllAsync())
            {
                return Ok("Cliente cadastrado com sucesso!");
            }

            return BadRequest("Ocorreu um erro ao salvar o cliente");
        }

        [HttpPut("Alterar")]
        public async Task<ActionResult> AlterarCliente(Cliente cliente)
        {
            // Verifica se o cliente possui um ID válido
            if (cliente.IdCliente <= 0)
            {
                return BadRequest("ID do cliente inválido.");
            }

            // Verifica se o cliente existe no banco de dados
            var clienteExistente = await _clienteRepository.SelecionarByPk(cliente.IdCliente);
            if (clienteExistente == null)
            {
                return NotFound("Cliente não encontrado.");
            }

            // Atualiza os dados do cliente existente com os dados recebidos
            clienteExistente.Nome = cliente.Nome;
            clienteExistente.Email = cliente.Email;
            clienteExistente.Telefone = cliente.Telefone;
            clienteExistente.DataCadastro = cliente.DataCadastro;

            // Chama o repositório para alterar o cliente
            _clienteRepository.Alterar(clienteExistente);

            // Salva as alterações no banco de dados
            if (await _clienteRepository.SaveAllAsync())
            {
                return Ok("Cliente alterado com sucesso!");
            }

            // Se algo deu errado, retorna um erro
            return BadRequest("Ocorreu um erro ao alterar o cliente.");
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> ExcluirCliente(int id)
        {
            var cliente = await _clienteRepository.SelecionarByPk(id);

            if (cliente == null)
            {
                return NotFound("Cliente não encontrado");
            }

            _clienteRepository.Excluir(cliente);

            if (await _clienteRepository.SaveAllAsync())
            {
                return Ok("Cliente excluído com sucesso!");
            }

            return BadRequest("Ocorreu um erro ao excluir o cliente!");
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> SelecionarCLiente(int id)
        {
            var cliente = await _clienteRepository.SelecionarByPk(id);

            if (cliente == null)
            {
                return NotFound("Cliente não encontrado");
            }

            return Ok(cliente);
        }
    }
}

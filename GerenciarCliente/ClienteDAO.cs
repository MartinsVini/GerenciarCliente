using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GerenciarCliente
{
    
    public class ClienteDAO : DAO<Cliente>



    {
        private readonly Conexao _dbContext;
        public ClienteDAO(Conexao conexaoClienteDAO)
        {
            _dbContext = conexaoClienteDAO;

        }

        [HttpGet]
        public async Task<Cliente> BuscarPorEmail(string Email)
        {

            var clientePorEmail = await _dbContext.Clientes.FirstOrDefaultAsync(x => x.Email == Email);

            return clientePorEmail ?? throw new Exception($"Cliente para o email: {Email} não foi encontrado!");
        }

        public async Task<List<Cliente>> BuscarTodos()
        {
            return await _dbContext.Clientes.ToListAsync();
        }
        public async Task<Cliente> Adicionar(Cliente cliente)
        {
            await _dbContext.Clientes.AddAsync(cliente);
            await _dbContext.SaveChangesAsync();

            return cliente;
        }

        public async Task<bool> Apagar(string email)
        {
            Cliente clientePorEmail = await BuscarPorEmail(email) ?? throw new Exception($"Cliente para o email: {email} não foi encontrado!");

            _dbContext.Clientes.Remove(clientePorEmail);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Cliente> Atualizar(Cliente cliente, string email)
        {

            Cliente clientePorEmail = await BuscarPorEmail(email) ?? throw new Exception($"Usuário para o email: {email} não foi encontrado!");
            clientePorEmail.Nome = cliente.Nome;
            clientePorEmail.CPF = cliente.CPF;
            clientePorEmail.DataNascimento = cliente.DataNascimento;
            clientePorEmail.Senha = cliente.Senha;
            _dbContext.Clientes.Update(clientePorEmail);
            await _dbContext.SaveChangesAsync();

            return clientePorEmail;

        }

        public async Task<bool>Logar(string email, string senha)
        {
            Cliente clientePorEmail = await BuscarPorEmail(email) ?? throw new Exception($"Usuário para o email: {email} não foi encontrado!");
            if(clientePorEmail.Email == email && clientePorEmail.Senha == senha) 
            {
                return true;
            }

            return false;
        }
    }
}

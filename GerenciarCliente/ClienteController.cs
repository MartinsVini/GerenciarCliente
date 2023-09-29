using Microsoft.AspNetCore.Mvc;

namespace GerenciarCliente
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly DAO<Cliente> clienteRepositorio;

        public ClienteController(ClienteDAO clienteRepositorio)
        {
            this.clienteRepositorio = clienteRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> BuscarTodos()
        {
            List<Cliente> clientes = await clienteRepositorio.BuscarTodos();
            return Ok(clientes);
        }

        [HttpGet("{senha}/login")]
        public async Task<ActionResult<Cliente>> Logar(string email, string senha)
        {
            bool logado = await clienteRepositorio.Logar(email, senha);
            return Ok(logado);
        }


        [HttpGet("{email}")]
        public async Task<ActionResult<List<Cliente>>> BuscarPorEmail(string email)
        {
            Cliente cliente = await clienteRepositorio.BuscarPorEmail(email);
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> Cadastrar([FromBody] Cliente cliente)
        {
            Cliente cliente1 = await clienteRepositorio.Adicionar(cliente);
            return Ok(cliente1);

        }

        [HttpPut("{email}")]
        public async Task<ActionResult<Cliente>> Atualizar([FromBody] Cliente cliente, string email)
        {
            cliente.Email  = email;
            Cliente cliente1 = await clienteRepositorio.Atualizar(cliente, email);
            return Ok(cliente1);

        }

        [HttpDelete("{email}")]
        public async Task<ActionResult<Cliente>> Apagar([FromBody] string email)
        {

            bool apagado = await clienteRepositorio.Apagar(email);
            return Ok(apagado);




        }

        
    }
}

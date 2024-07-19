using dotnet_web_api.Models;
using dotnet_web_api.Service.ClienteService;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace dotnet_web_api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]

    public class ClienteController : ControllerBase
    {
        private readonly IClienteInterface _clienteInterface;
        public ClienteController(IClienteInterface clienteIterface)
        {
            _clienteInterface = clienteIterface;
        }
        [HttpGet("retornar")]
        public async Task<ActionResult<ServiceResponse<List<ClienteModel>>>> Get()
        {
            return Ok(await _clienteInterface.GetClientes());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<ClienteModel>>> GetClienteById(int id)
        {
            return Ok(await _clienteInterface.GetClienteById(id));
        }

        [HttpPost("cadastrar")]
        public async Task<ActionResult<ServiceResponse<List<ClienteModel>>>> CreateCliente(ClienteModel novoCliente)
        {
            return Ok(await _clienteInterface.CreateCliente(novoCliente));
        }

        [HttpPut("editar")]
        public async Task<ActionResult<ServiceResponse<List<ClienteModel>>>> UpdateCliente(ClienteModel clienteEditado)
        {
            return Ok(await _clienteInterface.UpdateCliente(clienteEditado));
        }

        [HttpPut("inativar/{id}")]
        public async Task<ActionResult<ServiceResponse<List<ClienteModel>>>> InativaCLiente(int id)
        {
            return Ok(await _clienteInterface.InativaCliente(id));
        }

        [HttpDelete("apagar/{id}")]
        public async Task<ActionResult<ServiceResponse<List<ClienteModel>>>> DeleteCliente(int id)
        {
            return Ok(await _clienteInterface.DeleteCliente(id));
        }

    }
}
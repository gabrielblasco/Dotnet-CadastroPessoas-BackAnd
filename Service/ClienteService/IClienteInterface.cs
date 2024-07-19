using dotnet_web_api.Models;

namespace dotnet_web_api.Service.ClienteService
{
    public interface IClienteInterface
    {
        Task<ServiceResponse<List<ClienteModel>>> GetClientes();
        Task<ServiceResponse<List<ClienteModel>>> CreateCliente(ClienteModel NovoCliente);
        Task<ServiceResponse<ClienteModel>> GetClienteById(int id);
        Task<ServiceResponse<List<ClienteModel>>> UpdateCliente(ClienteModel ClienteEditado);
        Task<ServiceResponse<List<ClienteModel>>> DeleteCliente(int id);
        Task<ServiceResponse<List<ClienteModel>>> InativaCliente(int id);
    }
}
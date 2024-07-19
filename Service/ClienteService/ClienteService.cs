using dotnet_web_api.DataContext;
using dotnet_web_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace dotnet_web_api.Service.ClienteService
{
    public class ClienteService : IClienteInterface
    {
        private readonly ApplicationDbContext _context;

        public ClienteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<ClienteModel>>> CreateCliente(ClienteModel novoCliente)
        {
            ServiceResponse<List<ClienteModel>> serviceResponse = new();

            try
            {
                if (novoCliente == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar cliente";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;

                }
                _context.Add(novoCliente);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Clientes.ToList();
                serviceResponse.Mensagem = "Cadastro efetuado com sucesso";
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ClienteModel>>> DeleteCliente(int id)
        {
            ServiceResponse<List<ClienteModel>> serviceResponse = new();
            try
            {
                ClienteModel cliente = _context.Clientes.FirstOrDefault(x => x.Id == id);

                if (cliente == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Cadastro do cliente não localizado";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }

                _context.Remove(cliente);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Clientes.ToList();
                serviceResponse.Mensagem = "Cadastro apagado";

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ClienteModel>>> GetClientes()
        {
            ServiceResponse<List<ClienteModel>> serviceResponse = new();

            try
            {
                serviceResponse.Dados = _context.Clientes.ToList();

                if (serviceResponse.Dados.IsNullOrEmpty())
                {
                    serviceResponse.Mensagem = "Sem dados a serem exibidos";
                    return serviceResponse;
                }

                serviceResponse.Mensagem = "Consulta realizada com sucesso";
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<ClienteModel>> GetClienteById(int id)
        {
            ServiceResponse<ClienteModel> serviceResponse = new();

            try
            {
                ClienteModel cliente = _context.Clientes.FirstOrDefault(x => x.Id == id);

                if (cliente == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Cadastro do usuário não localizado";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }

                serviceResponse.Dados = cliente;
                serviceResponse.Mensagem = "Consulta realizada com sucesso";

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ClienteModel>>> InativaCliente(int id)
        {
            ServiceResponse<List<ClienteModel>> serviceResponse = new();
            try
            {
                ClienteModel cliente = _context.Clientes.FirstOrDefault(x => x.Id == id);

                if (cliente == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Cadastro do usuário não localizado";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }

                cliente.Ativo = false;
                _context.Update(cliente);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Clientes.ToList();
                serviceResponse.Mensagem = "Cadastro inativado";

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ClienteModel>>> UpdateCliente(ClienteModel clienteEditado)
        {
            ServiceResponse<List<ClienteModel>> serviceResponse = new();
            try
            {
                ClienteModel cliente = _context.Clientes.AsNoTracking().FirstOrDefault(x => x.Id == clienteEditado.Id);

                if (cliente == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Cadastro do usuário não localizado";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }

                _context.Update(clienteEditado);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Clientes.ToList();
                serviceResponse.Mensagem = "Cadastro atualizado";

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }
    }
}
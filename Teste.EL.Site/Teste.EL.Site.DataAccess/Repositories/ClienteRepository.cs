using System;
using System.Collections.Generic;
using System.Text;
using Teste.EL.Site.Entidades.DTO;

namespace Teste.EL.Site.Infrastructure.Repositories
{
    public class ClienteRepository : BaseRepository.BaseRepository
    {
        private readonly string _rotaClientes;
        public ClienteRepository() : base(Environment.GetEnvironmentVariable("URL_BASE_API_INTEGRATION"))
        {
            _rotaClientes = "v1/Clientes";
        }
        public ClienteDTO RegistrarCliente(ClienteDTO cliente, string jwtoken)
        {
            ClienteDTO retorno = Post<ClienteDTO>(_rotaClientes + "/", jwtoken, cliente);
            return retorno;
        }
        public ClienteDTO ObterPorId(int idCliente, string jwtoken)
        {
            ClienteDTO retorno = Get<ClienteDTO>($"{_rotaClientes}/{idCliente}", jwtoken, null);
            return retorno;
        }
    }
}

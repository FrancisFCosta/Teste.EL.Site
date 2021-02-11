using System;
using System.Collections.Generic;
using System.Text;
using Teste.EL.Site.Entidades.DTO;
using Teste.EL.Site.Infrastructure.Repositories;

namespace Teste.EL.Site.Business.BLL
{
    public class ClienteBusiness
    {
        private readonly ClienteRepository _clienteRepository;
        public ClienteBusiness()
        {
            _clienteRepository = new ClienteRepository();
        }
        public ClienteDTO RegistrarCliente(ClienteDTO cliente, string jwtoken)
        {
            return _clienteRepository.RegistrarCliente(cliente, jwtoken);
        }
        public ClienteDTO ObterPorId(int idCliente, string jwtoken)
        {
            return _clienteRepository.ObterPorId(idCliente, jwtoken);
        }
    }
}

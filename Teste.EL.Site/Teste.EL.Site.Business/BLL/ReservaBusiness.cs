using System;
using System.Collections.Generic;
using System.Text;
using Teste.EL.Site.Entidades.DTO;
using Teste.EL.Site.Infrastructure.Repositories;

namespace Teste.EL.Site.Business.BLL
{
    public class ReservaBusiness
    {
        private readonly AluguelRepository _reservaRepository;
        public ReservaBusiness()
        {
            _reservaRepository = new AluguelRepository();
        }

        public AluguelDTO SimularAluguel(AluguelDTO aluguel)
        {
            return _reservaRepository.SimularAluguel(aluguel);
        }

        public AluguelDTO EfetuarAluguel(AluguelDTO aluguel, string jwToken)
        {
            return _reservaRepository.EfetuarAluguel(aluguel, jwToken);
        }

        public List<AluguelDTO> ListarPorIdCliente(int idCliente, string jwToken)
        {
            return _reservaRepository.ListarPorIdCliente(idCliente, jwToken);
        }
    }
}

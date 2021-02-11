using System;
using System.Collections.Generic;
using System.Text;
using Teste.EL.Site.Entidades.DTO;

namespace Teste.EL.Site.Infrastructure.Repositories
{
    public class AluguelRepository : BaseRepository.BaseRepository
    {
        private readonly string _rotaAluguel;

        public AluguelRepository() : base(Environment.GetEnvironmentVariable("URL_BASE_API_INTEGRATION"))
        {
            _rotaAluguel = "v1/alugueis";
        }

        public AluguelDTO SimularAluguel(AluguelDTO aluguel)
        {
            AluguelDTO retorno = Post<AluguelDTO>($"{_rotaAluguel}/simulacao", null, aluguel);
            return retorno;
        }

        public AluguelDTO EfetuarAluguel(AluguelDTO aluguel, string jwToken)
        {
            AluguelDTO retorno = Post<AluguelDTO>($"{_rotaAluguel}/", jwToken, aluguel);
            return retorno;
        }

        public List<AluguelDTO> ListarPorIdCliente(int idCliente, string jwToken)
        {
            List<AluguelDTO> retorno = Get<List<AluguelDTO>>($"{_rotaAluguel}/clientes/{idCliente}", jwToken, null);
            return retorno;
        }
    }
}

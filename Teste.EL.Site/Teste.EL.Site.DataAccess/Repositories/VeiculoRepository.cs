using System;
using System.Collections.Generic;
using System.Text;
using Teste.EL.Site.DataTransferObjects.DTO;

namespace Teste.EL.Site.Infrastructure.Repositories
{
    public class VeiculoRepository : BaseRepository.BaseRepository
    {
        private readonly string _rotaAutenticacao;
        public VeiculoRepository() : base(Environment.GetEnvironmentVariable("URL_BASE_API_INTEGRATION"))
        {
            _rotaAutenticacao = "v1/veiculos";
        }

        public List<VeiculoDTO> ListarDisponiveis(string jwtoken)
        {
            List<VeiculoDTO> retorno = Get<List<VeiculoDTO>>($"{_rotaAutenticacao}/disponiveis", jwtoken, null);
            return retorno;
        }
    }
}

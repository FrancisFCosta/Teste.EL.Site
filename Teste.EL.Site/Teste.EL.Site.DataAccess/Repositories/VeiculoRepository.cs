using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Teste.EL.Site.DataTransferObjects.DTO;
using Teste.EL.Site.Entidades.Enum;

namespace Teste.EL.Site.Infrastructure.Repositories
{
    public class VeiculoRepository : BaseRepository.BaseRepository
    {
        private readonly string _rotaAutenticacao;
        public VeiculoRepository() : base(Environment.GetEnvironmentVariable("URL_BASE_API_INTEGRATION"))
        {
            _rotaAutenticacao = "v1/veiculos";
        }

        public List<VeiculoDTO> ListarDisponiveis()
        {
            List<VeiculoDTO> retorno = Get<List<VeiculoDTO>>($"{_rotaAutenticacao}/disponiveis", null, null);
            return retorno;
        }

        public VeiculoDTO ObterPorPlaca(string placa)
        {
            VeiculoDTO retorno = Get<VeiculoDTO>($"{_rotaAutenticacao}/{placa.Trim()}", null, null);
            return retorno;
        }

        public List<VeiculoDTO> ListarDisponiveisPorCategoria(CategoriaVeiculo categoria)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add(nameof(categoria), ((int)categoria).ToString());

            List<VeiculoDTO> retorno = Get<List<VeiculoDTO>>($"{_rotaAutenticacao}/categoria", null, parametros);
            return retorno;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Teste.EL.Site.DataTransferObjects.DTO;
using Teste.EL.Site.Entidades.Enum;
using Teste.EL.Site.Infrastructure.Repositories;

namespace Teste.EL.Site.Business.BLL
{
    public class VeiculoBusiness
    {
        private readonly VeiculoRepository _veiculoRepository;
        public VeiculoBusiness()
        {
            _veiculoRepository = new VeiculoRepository();
        }

        public VeiculoDTO ObterPorPlaca(string placa)
        {
            return _veiculoRepository.ObterPorPlaca(placa);
        }

        public List<VeiculoDTO> ListarDisponiveis()
        {
            return _veiculoRepository.ListarDisponiveis();
        }

        public List<VeiculoDTO> ListarDisponiveisPorCategoria(CategoriaVeiculo categoria)
        {
            return _veiculoRepository.ListarDisponiveisPorCategoria(categoria);
        }
    }
}

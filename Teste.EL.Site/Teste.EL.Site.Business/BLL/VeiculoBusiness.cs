using System;
using System.Collections.Generic;
using System.Text;
using Teste.EL.Site.DataTransferObjects.DTO;
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

        public List<VeiculoDTO> ListarDisponiveis(string jwtoken)
        {
            return _veiculoRepository.ListarDisponiveis(jwtoken);
        }
    }
}

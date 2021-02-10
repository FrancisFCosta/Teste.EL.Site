using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.EL.Site.DataTransferObjects.DTO;

namespace Teste.EL.Site.Web.Models
{
    public class SimulacaoReservaModel
    {
        public int IdVeiculo { get; set; }
        public string Placa { get; set; }
        public double ValorHoraVeiculo { get; set; }
        public double TotalHorasAluguel { get; set; }
        public DateTime DataPrevista { get; set; }

        public SimulacaoReservaModel()
        {}

        public SimulacaoReservaModel(VeiculoDTO veiculoDTO) 
        {
            if (veiculoDTO != null)
            {
                IdVeiculo = veiculoDTO.IdVeiculo;
                Placa = veiculoDTO.Placa;
                ValorHoraVeiculo = veiculoDTO.ValorHora;
            }
        }
    }
}

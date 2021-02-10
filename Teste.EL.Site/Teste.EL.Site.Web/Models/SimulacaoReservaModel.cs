using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste.EL.Site.Web.Models
{
    public class SimulacaoReservaModel
    {
        public int IdVeiculo { get; set; }
        public double ValorHoraVeiculo { get; set; }
        public double TotalHorasAluguel { get; set; }
        public double DataPrevista { get; set; }
    }
}

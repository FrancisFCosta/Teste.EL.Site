using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.EL.Site.DataTransferObjects.DTO;

namespace Teste.EL.Site.Web.Models
{
    public class VeiculoModel
    {
        public int IdVeiculo { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Ano { get; set; }
        public double ValorHora { get; set; }
        public string Combustivel { get; set; }
        public double LimitePortamalas { get; set; }
        public string Categoria { get; set; }
        public bool EstaAlugado { get; set; }
    }
}

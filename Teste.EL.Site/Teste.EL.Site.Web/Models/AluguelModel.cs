using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.EL.Site.Entidades.Enum;

namespace Teste.EL.Site.Web.Models
{
    public class AluguelModel
    {
        public int IdAluguel { get; set; }
        public string Placa{ get; set; }
        public int IdCliente  { get; set; }
        public CategoriaVeiculo Categoria { get; set; }
        public double ValorHora { get; set; }
        public double TotalDeHoras { get; set; }
        public double ValorFinalAluguel { get; set; }
    }
}

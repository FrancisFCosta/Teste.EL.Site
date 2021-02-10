using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.EL.Site.Entidades.DTO;
using Teste.EL.Site.Entidades.Enum;

namespace Teste.EL.Site.Web.Models
{
    public class AluguelModel
    {
        public int IdAluguel { get; set; }
        public string Placa{ get; set; }
        public int IdVeiculo  { get; set; }
        public int IdCliente  { get; set; }
        public CategoriaVeiculo Categoria { get; set; }
        public DateTime DataPrevistaAluguel { get; set; }
        public double ValorHora { get; set; }
        public double TotalDeHoras { get; set; }
        public double ValorFinalAluguel { get; set; }

        public AluguelModel() { }
        public AluguelModel(AluguelDTO aluguel) 
        {
            if (aluguel != null)
            {
                IdAluguel = aluguel.IdAluguel;
                Placa = aluguel.Veiculo?.Placa;
                IdVeiculo = aluguel.Veiculo != null ? aluguel.Veiculo.IdVeiculo : 0;
                IdCliente = aluguel.Cliente != null? aluguel.Cliente.IdCliente : 0;
                Categoria = aluguel.Categoria;
                DataPrevistaAluguel = aluguel.DataPrevistaAluguel;
                ValorHora = aluguel.ValorHora;
                TotalDeHoras = aluguel.TotalDeHoras;
                ValorFinalAluguel = aluguel.ValorFinal;
            }
        }
    }
}

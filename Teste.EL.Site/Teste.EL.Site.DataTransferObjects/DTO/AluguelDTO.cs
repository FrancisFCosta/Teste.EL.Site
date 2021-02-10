using System;
using System.Collections.Generic;
using System.Text;
using Teste.EL.Site.DataTransferObjects.DTO;
using Teste.EL.Site.Entidades.Enum;

namespace Teste.EL.Site.Entidades.DTO
{
    public class AluguelDTO
    {
        public int IdAluguel { get; set; }
        public VeiculoDTO Veiculo { get; set; }
        public ClienteDTO Cliente { get; set; }
        public CategoriaVeiculo Categoria { get; set; }
        public DateTime DataPrevistaAluguel { get; set; }
        public double ValorHora { get; set; }
        public double TotalDeHoras { get; set; }
        public double ValorFinal { get; set; }
    }
}

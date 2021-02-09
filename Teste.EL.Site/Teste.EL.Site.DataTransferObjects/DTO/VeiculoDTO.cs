using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.EL.Site.DataTransferObjects.DTO
{
    public class VeiculoDTO
    {
        public int IdVeiculo { get; set; }
        public string Placa { get; set; }
        public MarcaDTO Marca { get; set; }
        public ModeloDTO Modelo { get; set; }
        public string Ano { get; set; }
        public double ValorHora { get; set; }
        public string Combustivel { get; set; }
        public double LimitePortamalas { get; set; }
        public string Categoria { get; set; }
        public bool EstaAlugado { get; set; }

        public VeiculoDTO()
        {
            Marca = new MarcaDTO();
            Modelo = new ModeloDTO();
        }
    }
}

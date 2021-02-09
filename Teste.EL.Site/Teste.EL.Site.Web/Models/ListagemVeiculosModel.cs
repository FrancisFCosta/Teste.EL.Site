using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.EL.Site.DataTransferObjects.DTO;
using Teste.EL.Site.Entidades.Enum;

namespace Teste.EL.Site.Web.Models
{
    public class ListagemVeiculosModel
    {
        public List<VeiculoDTO> ListaVeiculosDisponiveis { get; set; }
        public List<SelectListItem> ListaCategorias { get; set; }
        public CategoriaVeiculo? CategoriaSelecionada { get; set; }
        public ListagemVeiculosModel(CategoriaVeiculo? categoriaSelecionada)
        {
            CategoriaSelecionada = categoriaSelecionada;
            ListaVeiculosDisponiveis = new List<VeiculoDTO>();

            for (int i = 0; i < 5; i++)
            {
                ListaVeiculosDisponiveis.Add(new VeiculoDTO()
                {
                    Placa = "QUH1051",
                    Ano = "2020/2020",
                    Combustivel = "Alcool",
                    Categoria = "Basico",
                    LimitePortamalas = 320,
                    Modelo = new ModeloDTO() { DescricaoModelo = "ARGO DRIVE 1.0" },
                    Marca = new MarcaDTO() { DescricaoMarca = "FIAT", IdMarca = 1 },
                    ValorHora = 27.99
                });
            }

            ListaCategorias = CriarListaOpcoesCategoria(categoriaSelecionada);
        }

        private List<SelectListItem> CriarListaOpcoesCategoria(CategoriaVeiculo? categoriaSelecionada)
        {
            var listaCategorias = Enum.GetValues(typeof(Teste.EL.Site.Entidades.Enum.CategoriaVeiculo));
            var listaResultado = new List<SelectListItem>() { new SelectListItem() { Value = "", Text = "Categorias Disponíveis", Selected = true } };

            listaResultado.Add(new SelectListItem() { Value = ((int)CategoriaVeiculo.Basico).ToString(), Text = Enum.GetName(typeof(CategoriaVeiculo), CategoriaVeiculo.Basico), Selected = categoriaSelecionada == CategoriaVeiculo.Basico });
            listaResultado.Add(new SelectListItem() { Value = ((int)CategoriaVeiculo.Completo).ToString(), Text = Enum.GetName(typeof(CategoriaVeiculo), CategoriaVeiculo.Completo), Selected = categoriaSelecionada == CategoriaVeiculo.Completo });
            listaResultado.Add(new SelectListItem() { Value = ((int)CategoriaVeiculo.Luxo).ToString(), Text = Enum.GetName(typeof(CategoriaVeiculo), CategoriaVeiculo.Luxo), Selected = categoriaSelecionada == CategoriaVeiculo.Luxo });

            return listaResultado;
        }
    }
}

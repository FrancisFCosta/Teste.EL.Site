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
        public List<VeiculoModel> ListaVeiculosDisponiveis { get; set; }
        public List<SelectListItem> ListaCategorias { get; set; }
        public CategoriaVeiculo? CategoriaSelecionada { get; set; }

        public ListagemVeiculosModel(List<VeiculoDTO> listaVeiculosDTO, CategoriaVeiculo? categoriaSelecionada = null)
        {
            CategoriaSelecionada = categoriaSelecionada;
            PreencherModelVeiculos(listaVeiculosDTO);
            PreencherListaOpcoesCategoria(categoriaSelecionada);
        }

        private void PreencherModelVeiculos(List<VeiculoDTO> listaVeiculosDTO)
        {
            ListaVeiculosDisponiveis = new List<VeiculoModel>();

            if (listaVeiculosDTO != null)
            {
                foreach (var veiculoDTO in listaVeiculosDTO)
                {
                    ListaVeiculosDisponiveis.Add(new VeiculoModel()
                    {
                        IdVeiculo = veiculoDTO.IdVeiculo,
                        Placa = veiculoDTO.Placa,
                        Marca = veiculoDTO.Marca?.DescricaoMarca,
                        Modelo = veiculoDTO.Modelo?.DescricaoModelo,
                         Ano = veiculoDTO.Ano,
                        ValorHora = veiculoDTO.ValorHora,
                        Combustivel = veiculoDTO.Combustivel,
                        LimitePortamalas = veiculoDTO.LimitePortamalas,
                        Categoria = veiculoDTO.Categoria,
                        EstaAlugado = veiculoDTO.EstaAlugado
                    });
                }
            }
        }

        private void PreencherListaOpcoesCategoria(CategoriaVeiculo? categoriaSelecionada)
        {
            ListaCategorias = new List<SelectListItem>();
            ListaCategorias.Add(new SelectListItem() { Value = "", Text = "Categorias Disponíveis", Selected = true });
            ListaCategorias.Add(new SelectListItem() { Value = ((int)CategoriaVeiculo.Basico).ToString(), Text = Enum.GetName(typeof(CategoriaVeiculo), CategoriaVeiculo.Basico), Selected = categoriaSelecionada == CategoriaVeiculo.Basico });
            ListaCategorias.Add(new SelectListItem() { Value = ((int)CategoriaVeiculo.Completo).ToString(), Text = Enum.GetName(typeof(CategoriaVeiculo), CategoriaVeiculo.Completo), Selected = categoriaSelecionada == CategoriaVeiculo.Completo });
            ListaCategorias.Add(new SelectListItem() { Value = ((int)CategoriaVeiculo.Luxo).ToString(), Text = Enum.GetName(typeof(CategoriaVeiculo), CategoriaVeiculo.Luxo), Selected = categoriaSelecionada == CategoriaVeiculo.Luxo });
        }
    }
}

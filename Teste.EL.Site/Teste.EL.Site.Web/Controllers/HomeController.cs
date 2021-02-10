using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Teste.EL.Site.DataTransferObjects.DTO;
using Teste.EL.Site.Entidades.Enum;
using Teste.EL.Site.Web.Models;

namespace Teste.EL.Site.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(CategoriaVeiculo? categoriaSelecionada)
        {
            if (categoriaSelecionada.HasValue)
                return View(new ListagemVeiculosModel(ListarVeiculosPorCategoria(categoriaSelecionada)));

            return View(new ListagemVeiculosModel(ListarVeiculosPorCategoria(categoriaSelecionada)));
        }

        public PartialViewResult ListarVeiculos(int? categoriaSelecionada)
        {
            var categoria = (CategoriaVeiculo?)categoriaSelecionada;

            var listaVeiculos = ListarVeiculosPorCategoria(categoria);

            return PartialView("~/Views/Home/_ListaVeiculos.cshtml", new ListagemVeiculosModel(listaVeiculos, categoria));
        }

        private List<VeiculoDTO> ListarVeiculosPorCategoria(CategoriaVeiculo? categoria)
        {
            //simula busca na base

            List<VeiculoDTO> listaVeiculosDisponiveis = new List<VeiculoDTO>();
            for (int i = 0; i < 6; i++)
            {
                listaVeiculosDisponiveis.Add(new VeiculoDTO()
                {
                    IdVeiculo = i + 1,
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

            return listaVeiculosDisponiveis;
        }
    }
}

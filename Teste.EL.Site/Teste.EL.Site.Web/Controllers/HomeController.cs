using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Teste.EL.Site.Business.BLL;
using Teste.EL.Site.DataTransferObjects.DTO;
using Teste.EL.Site.Entidades.Enum;
using Teste.EL.Site.Web.Models;

namespace Teste.EL.Site.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly VeiculoBusiness _veiculoBLL;


        public HomeController()
        {
            _veiculoBLL = new VeiculoBusiness();
        }

        public IActionResult Index()
        {
            base.PreencherViewBagUsuarioLogado();
            return View(new ListagemVeiculosModel(ListarVeiculosPorCategoria(null)));
        }

        public PartialViewResult ListarVeiculos([FromQuery] CategoriaVeiculo? categoria)
        {
            var listaVeiculos = ListarVeiculosPorCategoria(categoria);

            return PartialView("~/Views/Home/_ListaVeiculos.cshtml", new ListagemVeiculosModel(listaVeiculos, categoria));
        }

        private List<VeiculoDTO> ListarVeiculosPorCategoria(CategoriaVeiculo? categoria)
        {
            if (categoria.HasValue)
                return _veiculoBLL.ListarDisponiveisPorCategoria(categoria.Value);
            else
                return _veiculoBLL.ListarDisponiveis();
        }
    }
}

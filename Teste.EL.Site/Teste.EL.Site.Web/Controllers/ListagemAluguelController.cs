using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.EL.Site.Business.BLL;
using Teste.EL.Site.DataTransferObjects.DTO;
using Teste.EL.Site.Entidades.DTO;
using Teste.EL.Site.Entidades.Enum;
using Teste.EL.Site.Web.Models;

namespace Teste.EL.Site.Web.Controllers
{
    public class ListagemAluguelController : BaseController
    {
        private readonly ReservaBusiness _reservaBusiness;

        public ListagemAluguelController() 
        {
            _reservaBusiness = new ReservaBusiness();
        }

        public IActionResult Index()
        {
            List<AluguelDTO> listaAlugueisCliente = new List<AluguelDTO>();
            var cliente = ObterClienteLogado();

            if (cliente != null)
                listaAlugueisCliente = ListarAluguelPorCliente(cliente.IdCliente);

            base.PreencherViewBagUsuarioLogado();
            return View(new ListagemAluguelModel(listaAlugueisCliente));
        }

        public PartialViewResult ListarPorPeriodo([FromQuery] DateTime? periodoInicio, DateTime? periodoFinal)
        {
            List<AluguelDTO> listaAlugueisCliente = new List<AluguelDTO>();
            var cliente = ObterClienteLogado();

            if (cliente != null)
                listaAlugueisCliente = ListarAluguelPorCliente(cliente.IdCliente);

            if (periodoInicio.HasValue)
                listaAlugueisCliente.RemoveAll(aluguel => aluguel.DataPrevistaAluguel < periodoInicio.Value);

            if (periodoFinal.HasValue)
                listaAlugueisCliente.RemoveAll(aluguel => aluguel.DataPrevistaAluguel > periodoFinal.Value);

            return PartialView("~/Views/ListagemAluguel/_GridAlugueis.cshtml", new ListagemAluguelModel(listaAlugueisCliente));
        }

        private List<AluguelDTO> ListarAluguelPorCliente(int idCliente)
        {
            return _reservaBusiness.ListarPorIdCliente(idCliente, ObterJWToken());
        }
    }
}

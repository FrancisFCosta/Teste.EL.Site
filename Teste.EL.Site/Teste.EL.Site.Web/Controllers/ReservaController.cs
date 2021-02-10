using Microsoft.AspNetCore.Mvc;
using Teste.EL.Site.Business.BLL;
using Teste.EL.Site.Web.Models;

namespace Teste.EL.Site.Web.Controllers
{
    public class ReservaController : Controller
    {
        private readonly VeiculoBusiness _veiculoBLL;

        public ReservaController()
        {
            _veiculoBLL = new VeiculoBusiness();
        }

        public IActionResult Index(string placa)
        {
            var veiculo = _veiculoBLL.ObterPorPlaca(placa);
            return View(new SimulacaoReservaModel(veiculo));
        }

        public IActionResult SimularReserva(int idVeiculo)
        {
            return View("ResumoReserva");
        }

        public IActionResult ConcluirReserva(AluguelModel aluguel)
        {
            return View("ReservaConcluida");
        }
    }
}

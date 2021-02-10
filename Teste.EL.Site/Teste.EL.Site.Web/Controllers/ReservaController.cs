using Microsoft.AspNetCore.Mvc;
using Teste.EL.Site.Web.Models;

namespace Teste.EL.Site.Web.Controllers
{
    public class ReservaController : Controller
    {
        public IActionResult Index(int idVeiculo)
        {
            return View();
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

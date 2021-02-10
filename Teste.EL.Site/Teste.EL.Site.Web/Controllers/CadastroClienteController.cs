using Microsoft.AspNetCore.Mvc;
using Teste.EL.Site.Entidades.DTO;
using Teste.EL.Site.Web.Models;

namespace Teste.EL.Site.Web.Controllers
{
    public class CadastroClienteController : Controller
    {

        public IActionResult Index()
        {
            //if (!idCliente.HasValue)
            //    return RedirectToAction("Login", "CadastroUsuario");

            ClienteDTO cliente = ObterClientePorId(1);
            return View(new ClienteModel(cliente));
        }

        private ClienteDTO ObterClientePorId(int value)
        {
            return new ClienteDTO();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste.EL.Site.Web.Controllers
{
    public class CadastroUsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Cadastrar()
        {
            return View();
        }
    }
}

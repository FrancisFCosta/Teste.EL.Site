using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.EL.Site.Business;
using Teste.EL.Site.Business.BLL;
using Teste.EL.Site.Entidades.DTO;
using Teste.EL.Site.Web.Models;

namespace Teste.EL.Site.Web.Controllers
{
    public class CadastroUsuarioController : Controller
    {
        private readonly AutenticacaoBusiness _autenticacaoBLL;

        public CadastroUsuarioController()
        {
            _autenticacaoBLL = new AutenticacaoBusiness();
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login(UsuarioModel usuarioModel)
        {
            UsuarioDTO usuarioDTO = ConverterModelParaDTO(usuarioModel);

            if (usuarioDTO != null && !String.IsNullOrWhiteSpace(usuarioDTO.Login) && !String.IsNullOrWhiteSpace(usuarioDTO.Senha))
            {
               var autenticacao = _autenticacaoBLL.EfetuarLogin(usuarioDTO);
            }

            return View();
        }


        public IActionResult Cadastrar()
        {
            return View();
        }

        private UsuarioDTO ConverterModelParaDTO(UsuarioModel usuarioModel)
        {
            if (usuarioModel == null)
                return null;

            return new UsuarioDTO()
            {
                IdUsuario = usuarioModel.IdUsuario,
                Login = usuarioModel.Login,
                Perfil = usuarioModel.Perfil,
                Senha = usuarioModel.Senha
            }; 
        }
    }
}

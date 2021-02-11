using Microsoft.AspNetCore.Mvc;
using System;
using Teste.EL.Site.Business.BLL;
using Teste.EL.Site.Entidades.DTO;
using Teste.EL.Site.Web.Models;

namespace Teste.EL.Site.Web.Controllers
{
    public class CadastroUsuarioController : BaseController
    {
        private readonly AutenticacaoBusiness _autenticacaoBLL;
        private readonly UsuarioBusiness _usuarioBLL;

        public CadastroUsuarioController()
        {
            _autenticacaoBLL = new AutenticacaoBusiness();
            _usuarioBLL = new UsuarioBusiness();
        }

        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public IActionResult Login(UsuarioModel usuarioModel)
        {
            UsuarioDTO usuarioDTO = ConverterModelParaDTO(usuarioModel);
            AutenticacaoDTO auth = null;

            if (usuarioDTO != null && !String.IsNullOrWhiteSpace(usuarioDTO.Login) && !String.IsNullOrWhiteSpace(usuarioDTO.Senha))
            {
                auth = AutenticarUsuario(usuarioDTO);
                if (auth != null)
                {
                    if (usuarioModel.PreReserva)
                        return RedirectToAction("ConcluirReserva", "Reserva");
                    return RedirectToAction("Index", "Home");
                }
            }
            else if (VerificarUsuarioLogado())
            {
                return RedirectToAction("Index", "CadastroCliente");
            }

            base.PreencherViewBagUsuarioLogado();
            return View("Login", usuarioModel);
        }

        public IActionResult Cadastrar(UsuarioModel usuarioModel)
        {

            var usuarioLogado = ObterUsuarioLogado();
            if (usuarioLogado != null)
                return View(usuarioLogado);
            return View("CadastrarUsuario", usuarioModel);
        }

        public IActionResult RegistrarUsuario(UsuarioModel usuarioModel)
        {
            var usuarioDTO = ConverterModelParaDTO(usuarioModel);
            AutenticacaoDTO auth = null;
            if (usuarioDTO != null)
            {
                var usuario = _usuarioBLL.RegistrarUsuario(usuarioDTO);
                auth = AutenticarUsuario(usuario);
            }
            if (usuarioModel.PreReserva)
                return RedirectToAction("ConcluirReserva", "Reserva");

            if (auth != null)
                return RedirectToAction("Index", "Home");
            else
                return RedirectToAction("Cadastrar", "CadastroUsuario", usuarioModel);
        }

        public IActionResult Loggout()
        {
            RemoverUsuarioCookie();
            return RedirectToAction("Index", "Home");
        }

        private AutenticacaoDTO AutenticarUsuario(UsuarioDTO usuario)
        {
            var autenticacao = _autenticacaoBLL.EfetuarLogin(usuario);

            if (autenticacao != null)
                base.RegistrarLoginCookie(new AutenticacaoModel(autenticacao));

            return autenticacao;
        }

        private UsuarioDTO ConverterModelParaDTO(UsuarioModel usuarioModel)
        {
            if (usuarioModel == null)
                return null;

            return new UsuarioDTO()
            {
                IdUsuario = usuarioModel.IdUsuario,
                Login = usuarioModel.Login,
                Perfil = Entidades.Enum.PerfilUsuario.Cliente,
                Senha = usuarioModel.Senha
            };
        }
    }
}

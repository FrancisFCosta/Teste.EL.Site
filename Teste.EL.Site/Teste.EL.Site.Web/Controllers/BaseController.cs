using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using Teste.EL.Site.Web.Models;

namespace Teste.EL.Site.Web.Controllers
{
    public class BaseController : Controller
    {
        private const string _chaveCookieAuth = "JWTOKEN";
        private const string _chaveCookieReserva = "R3S3RV4";


        protected void RegistrarLoginCookie(AutenticacaoModel autenticacao)
        {
            if (autenticacao != null)
            {
                CookieOptions cookieOptions = new CookieOptions();
                cookieOptions.Expires = DateTime.Now.AddMinutes(30);
                string value = JsonSerializer.Serialize<AutenticacaoModel>(autenticacao);
                Response.Cookies.Append(_chaveCookieAuth, value, cookieOptions);
            }
        }

        protected void RemoverUsuarioCookie()
        {
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Append(_chaveCookieAuth, String.Empty, cookieOptions);
        }

        protected UsuarioModel ObterUsuarioLogado()
        {
            var cookieValue = Request.Cookies[_chaveCookieAuth];
            if (!String.IsNullOrWhiteSpace(cookieValue))
            {
                var autenticacao = JsonSerializer.Deserialize<AutenticacaoModel>(cookieValue);
                return autenticacao?.Usuario ?? null;
            }
            return null;
        }

        protected String ObterJWToken()
        {
            var cookieValue = Request.Cookies[_chaveCookieAuth];
            if (!String.IsNullOrWhiteSpace(cookieValue))
            {
                var autenticacao = JsonSerializer.Deserialize<AutenticacaoModel>(cookieValue);
                return autenticacao?.Token;
            }
            return null;
        }

        protected ClienteModel ObterClienteLogado()
        {
            var cookieValue = Request.Cookies[_chaveCookieAuth];
            if (!String.IsNullOrWhiteSpace(cookieValue))
            {
                var autenticacao = JsonSerializer.Deserialize<AutenticacaoModel>(cookieValue);
                return autenticacao?.Cliente ?? null;
            }
            return null;
        }

        protected void AtualizarClienteCookie(ClienteModel cliente)
        {
            var cookieValue = Request.Cookies[_chaveCookieAuth];
            if (!String.IsNullOrWhiteSpace(cookieValue))
            {
                var autenticacao = JsonSerializer.Deserialize<AutenticacaoModel>(cookieValue);

                if (autenticacao != null)
                {
                    autenticacao.Cliente = cliente;
                    CookieOptions cookieOptions = new CookieOptions();
                    cookieOptions.Expires = DateTime.Now.AddMinutes(30);
                    string value = JsonSerializer.Serialize<AutenticacaoModel>(autenticacao);
                    Response.Cookies.Append(_chaveCookieAuth, value, cookieOptions);
                }
            }
        }

        protected void PreencherViewBagUsuarioLogado()
        {
            var usuario = ObterUsuarioLogado();
            ViewBag.UsuarioLogado = usuario != null;
            ViewBag.NomeUsuario = usuario?.NomeUsuario;
        }

        protected bool VerificarUsuarioLogado()
        {
            return ObterUsuarioLogado() != null;
        }

        protected void SalvarReservaCookie(AluguelModel aluguel)
        {
            if (aluguel != null)
            {
                CookieOptions cookieOptions = new CookieOptions();
                cookieOptions.Expires = DateTime.Now.AddMinutes(10);
                string value = JsonSerializer.Serialize<AluguelModel>(aluguel);
                Response.Cookies.Append(_chaveCookieReserva, value, cookieOptions);
            }
        }

        protected AluguelModel RecuperarReservaCookie()
        {
            var cookieValue = Request.Cookies[_chaveCookieReserva];
            if (!String.IsNullOrWhiteSpace(cookieValue))
            {
                var aluguel = JsonSerializer.Deserialize<AluguelModel>(cookieValue);
                return aluguel;
            }
            return null;
        }

    }
}

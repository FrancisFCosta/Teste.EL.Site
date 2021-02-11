using Microsoft.AspNetCore.Mvc;
using Teste.EL.Site.Business.BLL;
using Teste.EL.Site.Entidades.DTO;
using Teste.EL.Site.Web.Models;

namespace Teste.EL.Site.Web.Controllers
{
    public class CadastroClienteController : BaseController
    {
        private readonly ClienteBusiness _clienteBLL;

        public CadastroClienteController()
        {
            _clienteBLL = new ClienteBusiness();
        }

        public IActionResult Index(ClienteModel clienteModel)
        {
            ViewBag.PreReserva = clienteModel.PreReserva;
            var cliente = ObterClienteLogado();
            base.PreencherViewBagUsuarioLogado();
            return View(cliente);
        }

        public IActionResult RegistrarCliente(ClienteModel clienteModel)
        {
            if (clienteModel != null)
            {
                ClienteDTO clienteDTO = ConverterModelParaDTO(clienteModel);
                if (clienteDTO.IdCliente.Equals(0))
                    clienteDTO = _clienteBLL.RegistrarCliente(clienteDTO, ObterJWToken());
                else
                    _clienteBLL.AtualizarCliente(clienteDTO, ObterJWToken());

                AtualizarClienteCookie(new ClienteModel(clienteDTO));
                if (clienteDTO != null)
                {
                    if (clienteModel.PreReserva)
                        return RedirectToAction("ConcluirReserva", "Reserva");
                    else
                        return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index");
        }

        private static ClienteDTO ConverterModelParaDTO(ClienteModel clienteModel)
        {
            return new ClienteDTO()
            {
                IdCliente = clienteModel.IdCliente,
                Nome = clienteModel.Nome,
                CPF = clienteModel.CPF,
                Aniversario = clienteModel.Aniversario,
                Celular = clienteModel.Celular,
                Email = clienteModel.Email,
                Endereco = new EnderecoDTO()
                {
                    Logradouro = clienteModel.Endereco?.Logradouro,
                    Numero = clienteModel.Endereco?.Numero,
                    CEP = clienteModel.Endereco?.CEP,
                    Cidade = clienteModel.Endereco?.Cidade,
                    Estado = clienteModel.Endereco?.Estado,
                    Complemento = clienteModel.Endereco?.Complemento,
                }
            };
        }
    }
}
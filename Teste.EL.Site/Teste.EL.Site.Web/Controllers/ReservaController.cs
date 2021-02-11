﻿using Microsoft.AspNetCore.Mvc;
using Teste.EL.Site.Business.BLL;
using Teste.EL.Site.DataTransferObjects.DTO;
using Teste.EL.Site.Entidades.DTO;
using Teste.EL.Site.Web.Models;

namespace Teste.EL.Site.Web.Controllers
{
    public class ReservaController : BaseController
    {
        private readonly VeiculoBusiness _veiculoBLL;
        private readonly ReservaBusiness _reservaBLL;

        public ReservaController()
        {
            _veiculoBLL = new VeiculoBusiness();
            _reservaBLL = new ReservaBusiness();
        }

        public IActionResult Index(string placa)
        {
            var veiculo = _veiculoBLL.ObterPorPlaca(placa);
            base.PreencherViewBagUsuarioLogado();
            return View(new SimulacaoReservaModel(veiculo));
        }

        public IActionResult SimularReserva(SimulacaoReservaModel simulacaoReserva)
        {
            base.PreencherViewBagUsuarioLogado();

            if (simulacaoReserva != null)
            {
                AluguelDTO aluguelDTO = new AluguelDTO()
                {
                    Veiculo = new VeiculoDTO() { IdVeiculo = simulacaoReserva.IdVeiculo },
                    TotalDeHoras = simulacaoReserva.TotalHorasAluguel,
                    DataPrevistaAluguel = simulacaoReserva.DataPrevista
                };

                var aluguel = _reservaBLL.SimularAluguel(aluguelDTO);
                aluguel.Veiculo.Placa = simulacaoReserva.Placa;

                return View("ResumoReserva", new AluguelModel(aluguel));
            }
            else
            {
                return View("Index", "Home");
            }
        }

        public IActionResult ConcluirReserva(AluguelModel aluguel)
        {
            if (!VerificarUsuarioLogado())
            {
                SalvarReservaCookie(aluguel);
                return RedirectToAction("Login", "CadastroUsuario", new UsuarioModel() { PreReserva = true });
            }
            var clienteLogado = ObterClienteLogado();
            if (clienteLogado?.IdCliente == 0 && aluguel.IdCliente.Equals(0))
            {
                SalvarReservaCookie(aluguel);
                return RedirectToAction("Index", "CadastroCliente", new ClienteModel() { PreReserva = true });
            }

            var aluguelParaProcessamento = aluguel;
            aluguelParaProcessamento.IdCliente = clienteLogado.IdCliente;
            if (aluguelParaProcessamento != null)
            {
                AluguelDTO aluguelDTO = new AluguelDTO()
                {
                    Veiculo = new VeiculoDTO() { IdVeiculo = aluguel.IdVeiculo, Placa = aluguel.Placa },
                    Cliente = new ClienteDTO() { IdCliente = aluguel.IdCliente },
                    TotalDeHoras = aluguel.TotalDeHoras,
                    DataPrevistaAluguel = aluguel.DataPrevistaAluguel,
                    ValorHora = aluguel.ValorHora,
                    ValorFinal = aluguel.ValorFinalAluguel
                };

                _reservaBLL.EfetuarAluguel(aluguelDTO, ObterJWToken());
            }
            else
            {
                return View("Index", "Home");
            }
            base.PreencherViewBagUsuarioLogado();
            return View("ReservaConcluida");
        }
    }
}

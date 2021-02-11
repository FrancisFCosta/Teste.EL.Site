using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.EL.Site.DataTransferObjects.DTO;
using Teste.EL.Site.Entidades.DTO;
using Teste.EL.Site.Entidades.Enum;
using Teste.EL.Site.Web.Models;

namespace Teste.EL.Site.Web.Controllers
{
    public class ListagemAluguelController : BaseController
    {
        public IActionResult Index(int idCliente)
        {
            List<AluguelDTO> listaAlugueisCliente = ListarAluguelPorCliente(idCliente);
            base.PreencherViewBagUsuarioLogado();
            return View(new ListagemAluguelModel(listaAlugueisCliente));
        }

        private List<AluguelDTO> ListarAluguelPorCliente(int idCliente)
        {
            var listaAluguel = new List<AluguelDTO>();

            listaAluguel.Add(new AluguelDTO()
            {
                IdAluguel = 1,
                Cliente = new ClienteDTO() { IdCliente = 1 },
                Veiculo = new VeiculoDTO() { IdVeiculo = 1, Placa = "QUH1051" },
                Categoria = CategoriaVeiculo.Completo,
                ValorHora = 70.6,
                TotalDeHoras = 8
            });

            listaAluguel.Add(new AluguelDTO()
            {
                IdAluguel = 2,
                Cliente = new ClienteDTO() { IdCliente = 1 },
                Veiculo = new VeiculoDTO() { IdVeiculo = 1, Placa = "QXH6632" },
                Categoria = CategoriaVeiculo.Completo,
                ValorHora = 22.5,
                TotalDeHoras = 40,
            });

            return listaAluguel;
        }
    }
}

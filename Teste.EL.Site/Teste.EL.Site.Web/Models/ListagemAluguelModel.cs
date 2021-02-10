using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.EL.Site.Entidades.DTO;
using Teste.EL.Site.Entidades.Enum;

namespace Teste.EL.Site.Web.Models
{
    public class ListagemAluguelModel
    {
        public List<AluguelModel> ListaAluguelCliente { get; set; }

        public ListagemAluguelModel(List<AluguelDTO> listaAluguelDTO)
        {
            ListaAluguelCliente = new List<AluguelModel>();

            if (listaAluguelDTO != null)
            {
                foreach (var aluguel  in listaAluguelDTO)
                    ListaAluguelCliente.Add(new AluguelModel(aluguel)); 
            }
        }
    }
}

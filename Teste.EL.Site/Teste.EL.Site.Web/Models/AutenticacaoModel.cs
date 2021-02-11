using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.EL.Site.Entidades.DTO;

namespace Teste.EL.Site.Web.Models
{
    public class AutenticacaoModel
    {
        public UsuarioModel Usuario { get; set; }
        public ClienteModel Cliente { get; set; }
        public String Token { get; set; }

        public AutenticacaoModel() { }
        public AutenticacaoModel(AutenticacaoDTO autenticacaoDTO)
        {
            Cliente = new ClienteModel(autenticacaoDTO?.Cliente);
            Usuario = new UsuarioModel(autenticacaoDTO?.Usuario);
            Token = autenticacaoDTO?.Token;
            if (Usuario != null)
                Usuario.NomeUsuario = Cliente?.Nome;
        }
    }
}

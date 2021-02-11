using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.EL.Site.Entidades.DTO
{
    public class AutenticacaoDTO
    {
        public UsuarioDTO Usuario { get; set; }
        public ClienteDTO Cliente { get; set; }
        public String Token { get; set; }
    }
}

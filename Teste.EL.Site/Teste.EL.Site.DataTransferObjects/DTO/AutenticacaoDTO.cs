using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.EL.Site.Entidades.DTO
{
    public class AutenticacaoDTO
    {
        public UsuarioDTO usuario { get; set; }
        public ClienteDTO cliente { get; set; }
        public String token { get; set; }
    }
}

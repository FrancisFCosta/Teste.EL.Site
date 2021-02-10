using System;
using System.Collections.Generic;
using System.Text;
using Teste.EL.Site.Entidades.Enum;

namespace Teste.EL.Site.Entidades.DTO
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }
        public PerfilUsuario Perfil { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}

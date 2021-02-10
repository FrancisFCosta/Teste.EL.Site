using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.EL.Site.Entidades.Enum;

namespace Teste.EL.Site.Web.Models
{
    public class UsuarioModel
    {
        public int IdUsuario { get; set; }
        public PerfilUsuario Perfil { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string ConfirmacaoSenha { get; set; }
    }
}

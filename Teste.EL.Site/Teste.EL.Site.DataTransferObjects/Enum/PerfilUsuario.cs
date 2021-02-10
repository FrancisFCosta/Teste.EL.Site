using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Teste.EL.Site.Entidades.Enum
{
    public enum PerfilUsuario
    {
        [Description("Cliente")]
        Cliente = 1,
        [Description("Operador")]
        Operador = 2
    }
}

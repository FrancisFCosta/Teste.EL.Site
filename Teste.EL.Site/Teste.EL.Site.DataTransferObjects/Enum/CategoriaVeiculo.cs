using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Teste.EL.Site.Entidades.Enum
{
    public enum CategoriaVeiculo
    {
        [Description("Básico")]
        Basico = 1,
        [Description("Completo")]
        Completo = 2,
        [Description("Luxo")]
        Luxo = 3
    }
}

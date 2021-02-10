using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste.EL.Site.Web.Models
{
    public class EnderecoModel
    {
        public int? IdEndereco { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}

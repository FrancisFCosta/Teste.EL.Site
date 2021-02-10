using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.EL.Site.Entidades.DTO
{
    public class EnderecoDTO
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

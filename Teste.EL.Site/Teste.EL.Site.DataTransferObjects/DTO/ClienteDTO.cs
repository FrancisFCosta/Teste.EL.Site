using System;

namespace Teste.EL.Site.Entidades.DTO
{
    public class ClienteDTO
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime Aniversario { get; set; }
        public EnderecoDTO Endereco { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }

        public ClienteDTO() => Endereco = new EnderecoDTO();
    }
}
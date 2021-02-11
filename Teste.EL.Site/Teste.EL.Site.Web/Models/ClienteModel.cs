using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.EL.Site.Entidades.DTO;

namespace Teste.EL.Site.Web.Models
{
    public class ClienteModel
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime Aniversario { get; set; }
        public EnderecoModel Endereco { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public bool PreReserva { get; set; }
        
        public ClienteModel() { }
        public ClienteModel(ClienteDTO clienteDTO) 
        {
            if (clienteDTO != null)
            {
                IdCliente = clienteDTO.IdCliente;
                Nome = clienteDTO.Nome;
                CPF = clienteDTO.CPF;
                Aniversario = clienteDTO.Aniversario;
                Celular = clienteDTO.Celular;
                Email = clienteDTO.Email;

                if (clienteDTO.Endereco != null)
                {
                    Endereco = new EnderecoModel();

                    Endereco.Logradouro = Endereco.Logradouro;
                    Endereco.Numero = Endereco.Numero;
                    Endereco.CEP = Endereco.CEP;
                    Endereco.Cidade = Endereco.Cidade;
                    Endereco.Estado = Endereco.Estado;
                    Endereco.Complemento = Endereco.Complemento;
                    Endereco.IdEndereco = Endereco.IdEndereco;
                }
            }
        }
    }
}

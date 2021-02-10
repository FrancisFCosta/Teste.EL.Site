using System;
using System.Collections.Generic;
using System.Text;
using Teste.EL.Site.Entidades.DTO;
using Teste.EL.Site.Infrastructure.Repositories;

namespace Teste.EL.Site.Business.BLL
{
    public class AutenticacaoBusiness
    {
        private readonly AutenticacaoRepository _autenticacaoRepository;
        public AutenticacaoBusiness() 
        {
            _autenticacaoRepository = new AutenticacaoRepository();
        }

        public AutenticacaoDTO EfetuarLogin(UsuarioDTO usuario) 
        {
            return _autenticacaoRepository.EfeturaLogin(usuario);
        }
    }
}

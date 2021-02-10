using System;
using System.Collections.Generic;
using System.Text;
using Teste.EL.Site.Entidades.DTO;

namespace Teste.EL.Site.Infrastructure.Repositories
{
    public class AutenticacaoRepository : BaseRepository.BaseRepository
    {
        private readonly string _rotaAutenticacao;
        public AutenticacaoRepository():base(Environment.GetEnvironmentVariable("URL_BASE_API_INTEGRATION"))
        {
            _rotaAutenticacao = "v1/autenticacao/login";
        }

        public AutenticacaoDTO EfeturaLogin(UsuarioDTO usuario) 
        {
            AutenticacaoDTO retorno = Post<AutenticacaoDTO>(_rotaAutenticacao, null, usuario);
            return retorno;
        }
    }
}

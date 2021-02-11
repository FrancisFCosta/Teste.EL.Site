using System;
using System.Collections.Generic;
using System.Text;
using Teste.EL.Site.Entidades.DTO;
using Teste.EL.Site.Infrastructure.Repositories;

namespace Teste.EL.Site.Business.BLL
{
    public class UsuarioBusiness
    {
        private readonly UsuarioRepository _usuarioRepository;
        public UsuarioBusiness()
        {
            _usuarioRepository = new UsuarioRepository();
        }
        public UsuarioDTO RegistrarUsuario(UsuarioDTO usuario)
        {
            return _usuarioRepository.RegistrarUsuario(usuario);
        }
    }
}

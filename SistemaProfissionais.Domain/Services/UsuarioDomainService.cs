using SistemaProfissionais.Domain.Entities;
using SistemaProfissionais.Domain.Interfaces.Repositories;
using SistemaProfissionais.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProfissionais.Domain.Services
{
    public class UsuarioDomainService : IUsuarioDomainService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioDomainService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void CadastrarUsuario(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new Exception("O Sistema não pode cadastrar usuario.");
            }
            _usuarioRepository.Create(usuario);
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            if (_usuarioRepository.GetById(usuario.IdUsuario) == null)
            {
                throw new Exception("O Sistema não pode atualizar, verifique o id.");
            }
            _usuarioRepository.Update(usuario);
        }

        public void ExcluirUsuario(Usuario usuario)
        {
            if (_usuarioRepository.GetById(usuario.IdUsuario) == null)
            {
                throw new Exception("O Sistema não pode atualizar, verifique o id.");
            }
            _usuarioRepository.Delete(usuario);
        }

        public List<Usuario> ConsultarUsuarios()
        {
            if (_usuarioRepository.GetAll() == null)
            {
                throw new Exception("O Sistema não possui usuários.");
            }
           return _usuarioRepository.GetAll();
        }
      

        public Usuario ObterUsuario(Guid idUsuario)
        {
            if (_usuarioRepository.GetById(idUsuario) == null)
            {
                throw new Exception("O Sistema não pode consultar, verifique o id.");
            }
            return _usuarioRepository.GetById(idUsuario);
        }

        public Usuario ObterEmailAndSenha(string email, string senha)
        {
            var usuario = _usuarioRepository.GetByEmailAndSenha(email, senha);
            if (usuario == null)
            {
                throw new Exception("O Sistema não pode consultar, verifique o email.");
            }
            return usuario;
        }

        public Usuario ObterEmail(string email)
        {
            if (email == null)
            {
                throw new Exception("O Sistema não pode consultar, verifique o email.");
            }
            return _usuarioRepository.GetEmail(email);
        }
    }
}

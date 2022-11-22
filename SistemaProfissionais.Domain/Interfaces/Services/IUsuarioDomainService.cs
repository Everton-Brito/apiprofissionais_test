using SistemaProfissionais.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProfissionais.Domain.Interfaces.Services
{
    public interface IUsuarioDomainService
    {
        void CadastrarUsuario(Usuario usuario);
        void AtualizarUsuario(Usuario usuario);
        void ExcluirUsuario(Usuario usuario);
        List<Usuario> ConsultarUsuarios();
        Usuario ObterUsuario(Guid idUsuario);
        Usuario ObterEmailAndSenha(string email, string senha);
        Usuario ObterEmail(string email);

    }
}

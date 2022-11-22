using SistemaProfissionais.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProfissionais.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        void Create(Usuario usuario);
        void Update(Usuario usuario);
        void Delete(Usuario usuario);
        List<Usuario> GetAll();
        Usuario GetById(Guid idUsuario);
        Usuario GetByEmailAndSenha(string email, string senha);
        Usuario GetEmail(string email);
    }
}

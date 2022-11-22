using Microsoft.EntityFrameworkCore;
using SistemaProfissionais.Domain.Entities;
using SistemaProfissionais.Domain.Interfaces.Repositories;
using SistemaProfissionais.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProfissionais.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public void Create(Usuario usuario)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                sqlServerContext.Usuario.Add(usuario);
                sqlServerContext.SaveChanges();
            }
        }

        public void Update(Usuario usuario)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                sqlServerContext.Entry(usuario).State = EntityState.Modified;
                sqlServerContext.SaveChanges();
            }
        }

        public void Delete(Usuario usuario)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                sqlServerContext.Usuario.Remove(usuario);
                sqlServerContext.SaveChanges();
            }
        }

        public List<Usuario> GetAll()
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                return sqlServerContext.Usuario.OrderByDescending(u => u.DataCadastro).ToList();
            }
        }

        public Usuario GetById(Guid idUsuario)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                return sqlServerContext.Usuario.FirstOrDefault(u => u.IdUsuario == idUsuario);
            }
        }

        public Usuario GetByEmailAndSenha(string email, string senha)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                return sqlServerContext.Usuario.FirstOrDefault(u => u.Email == email && u.Senha == senha);
            }
        }

        public Usuario GetEmail(string email)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                return sqlServerContext.Usuario.FirstOrDefault(u => u.Email == email);
            }
        }
    }
}

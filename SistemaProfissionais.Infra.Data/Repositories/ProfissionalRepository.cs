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
    public class ProfissionalRepository : IProfissionalRepository
    {
        public void Create(Profissional profissional)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                sqlServerContext.Profissional.Add(profissional);
                sqlServerContext.SaveChanges();
            }
        }

        public void Update(Profissional profissional)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                sqlServerContext.Entry(profissional).State = EntityState.Modified;
                sqlServerContext.SaveChanges();
            }
        }

        public void Delete(Profissional profissional)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                sqlServerContext.Profissional.Remove(profissional);
                sqlServerContext.SaveChanges();
            }
        }      

        public Profissional GetById(Guid idProfissional)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                return sqlServerContext.Profissional.FirstOrDefault(p => p.IdProfissional == idProfissional);
            }
        }

        public Profissional GetProfissionalUnico(string cpf, string email, string telefone)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                return sqlServerContext.Profissional.FirstOrDefault(p => p.Cpf.Equals(cpf) && p.Email.Equals(email) && p.Telefone.Equals(telefone));
            }
        }

        public List<Profissional> GetAll( )
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                return sqlServerContext.Profissional.ToList();
            }
        }
    }
}

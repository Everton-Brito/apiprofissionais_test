using SistemaProfissionais.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProfissionais.Domain.Interfaces.Repositories
{
    public interface IProfissionalRepository
    {
        void Create(Profissional profissional);
        void Update(Profissional profissional);
        void Delete(Profissional profissional);
        List<Profissional> GetAll();
        Profissional GetById(Guid idProfissional);
        Profissional GetProfissionalUnico(string cpf, string email, string telefone);

    }
}

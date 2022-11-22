using SistemaProfissionais.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProfissionais.Domain.Interfaces.Services
{
    public interface IProfissionalDomainService
    {
        void CadastrarProfissional(Profissional profissional);
        void AtualizarProfissional(Profissional profissional);
        void ExcluirProfissional(Profissional profissional);
        List<Profissional> ConsultarProfissionais();
        Profissional ObterProfissional(Guid idProfissional);

    }
}

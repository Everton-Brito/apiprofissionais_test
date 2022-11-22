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
    public class ProfissionalDomainService : IProfissionalDomainService
    {
        private readonly IProfissionalRepository _profissionalRepository;

        public ProfissionalDomainService(IProfissionalRepository profissionalRepository)
        {
            _profissionalRepository = profissionalRepository;
        }

        public void CadastrarProfissional(Profissional profissional)
        {
            var consultar = _profissionalRepository.GetAll();
            foreach (var item in consultar)
            {
                if (item.Cpf.Equals(profissional.Cpf))
                    throw new Exception("O Sistema não pode cadastrar profissional com o mesmo cpf");
                else if(item.Email.Equals(profissional.Email))
                    throw new Exception("O Sistema não pode cadastrar profissional com o mesmo email");
                else if(item.Telefone.Equals(profissional.Telefone))
                    throw new Exception("O Sistema não pode cadastrar profissional com o mesmo telefone");
            }
            
            _profissionalRepository.Create(profissional);
        }

        public void AtualizarProfissional(Profissional profissional)
        {
            if (_profissionalRepository.GetById(profissional.IdProfissional) == null)
            {
                throw new Exception("O sistema não encontrou o profissional, verifique o id.");
            }
            _profissionalRepository.Update(profissional);
        }

        public void ExcluirProfissional(Profissional profissional)
        {
            if (_profissionalRepository.GetById(profissional.IdProfissional) == null)
            {
                throw new Exception("O sistema não encontrou o profissional, verifique o id.");
            }
            _profissionalRepository.Delete(profissional);
        }     
            

        public Profissional ObterProfissional(Guid idProfissional)
        {
            if (_profissionalRepository.GetById(idProfissional) == null)
            {
                throw new Exception("O sistema não encontrou o profissional, verifique o id.");
            }
            return _profissionalRepository.GetById(idProfissional);
        }

        public List<Profissional> ConsultarProfissionais()
        {
            if (_profissionalRepository.GetAll() == null)
            {
                throw new Exception("O sistema não encontrou o profissional, verifique o id.");
            }
            return _profissionalRepository.GetAll();
        }
    }
}

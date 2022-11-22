using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaProfissionais.Api.Model;
using SistemaProfissionais.Domain.Entities;
using SistemaProfissionais.Domain.Interfaces.Services;

namespace SistemaProfissionais.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProfissionaisController : ControllerBase
    {
        private readonly IProfissionalDomainService _profissionalDomainService;
        private readonly IUsuarioDomainService _usuarioDomainService;

        public ProfissionaisController(IProfissionalDomainService profissionalDomainService, IUsuarioDomainService usuarioDomainService)
        {
            _profissionalDomainService = profissionalDomainService;
            _usuarioDomainService = usuarioDomainService;
        }

        [HttpPost]
        public IActionResult Post(ProfissionaisPostModel model)
        {
            try
            {
                var email = User.Identity.Name;
                var usuario = _usuarioDomainService.ObterEmail(email);
                var id = _usuarioDomainService.ObterUsuario(usuario.IdUsuario);               

                var profissional = new Profissional();
                profissional.IdProfissional = Guid.NewGuid();
                profissional.IdUsuario = id.IdUsuario;
                profissional.Nome = model.Nome;
                profissional.Email = model.Email;
                profissional.Cpf = model.Cpf;
                profissional.Telefone = model.Telefone;
               
                _profissionalDomainService.CadastrarProfissional(profissional);                
             
                return StatusCode(201, new { mensagem = $"Profissional {profissional.Nome} Cadastrado com sucesso." });

            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = "Dados já cadastrados, entre com novo email, cpf e telefone." });
            }
        }

        [HttpPut]
        public IActionResult Put(ProfissionaisPutModel model)
        {
            try
            {

                var profissional = _profissionalDomainService.ObterProfissional(model.IdProfissional);

                if (profissional != null)
                {
                    profissional.IdProfissional = model.IdProfissional;
                    profissional.Nome = model.Nome;
                    profissional.Email = model.Email;
                    profissional.Cpf = model.Cpf;
                    profissional.Telefone = model.Telefone;

                    _profissionalDomainService.AtualizarProfissional(profissional);

                    return StatusCode(200, new { mensagem = "Profissional atualizado com sucesso." });
                }
                return StatusCode(400, new { mensagem = "Profissional não encontrado, verifique o ID informado." });

            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = e.Message });
            }
        }

        [HttpDelete("{idProfissional}")]
        public IActionResult Delete(Guid idProfissional)
        {
            var profissional = _profissionalDomainService.ObterProfissional(idProfissional);
            if (profissional != null)
            {
                _profissionalDomainService.ExcluirProfissional(profissional);

                return StatusCode(200, new { mensagem = $"Profissional {profissional.Nome} excluído com sucesso." });
            }
            return StatusCode(400, new { mensagem = "Profissional não encontrado, verifique o ID informado." });
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ProfissionaisGetModel>))]
        public IActionResult GetAll()
        {
            try
            {
                var lista = new List<ProfissionaisGetModel>();
                var email = User.Identity.Name;                
                var usuario = _usuarioDomainService.ObterEmail(email);

                foreach (var item in _profissionalDomainService.ConsultarProfissionais())
                {
                    var model = new ProfissionaisGetModel();

                    model.IdProfissional = item.IdProfissional;
                    model.Nome = item.Nome;
                    model.Email = item.Email;
                    model.Cpf = item.Cpf;
                    model.Telefone = item.Telefone;

                    lista.Add(model);
                }
                return StatusCode(200, lista);
            }
            catch (Exception e)
            {
                return StatusCode(500, new {mensagem = e.Message});
            }
           
        }

        [HttpGet("{idProfissional}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProfissionaisGetModel))]
        public IActionResult GetById(Guid idProfissional)
        {
            try
            {
                var profissional = _profissionalDomainService.ObterProfissional(idProfissional);
                if (profissional != null)
                {
                    var model = new ProfissionaisGetModel();

                    model.IdProfissional = profissional.IdProfissional;
                    model.Nome = profissional.Nome;
                    model.Email = profissional.Email;
                    model.Cpf= profissional.Cpf;
                    model.Telefone = profissional.Telefone;

                    return StatusCode(200, model);
                }
                else
                {
                    return StatusCode(204);
                }
                

            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = e.Message });
            }
        }
    }
}

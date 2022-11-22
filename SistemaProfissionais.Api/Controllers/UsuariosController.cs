using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaProfissionais.Api.Model;
using SistemaProfissionais.Domain.Entities;
using SistemaProfissionais.Domain.Interfaces.Repositories;
using SistemaProfissionais.Domain.Interfaces.Services;
using SistemaProfissionais.Infra.Data.Helper;

namespace SistemaProfissionais.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioDomainService _usuarioDomainService;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuariosController(IUsuarioDomainService usuarioDomainService, IUsuarioRepository usuarioRepository)
        {
            _usuarioDomainService = usuarioDomainService;
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        public IActionResult Post(UsuariosModel model)
        {
            try
            {
                if (_usuarioRepository.GetByEmailAndSenha(model.Email, model.Senha) == null)
                {
                    var usuario = new Usuario();
                    usuario.IdUsuario = Guid.NewGuid();
                    usuario.Nome = model.Nome;
                    usuario.Email = model.Email;
                    usuario.Senha = MD5Helper.Encrypt(model.Senha);
                    usuario.DataCadastro = DateTime.Now;

                    _usuarioRepository.Create(usuario);
                    return StatusCode(201, new { mensagem = $"Usuario {usuario.Nome} cadastrado com sucesso." });
                }
                return StatusCode(400, new { mensagem = "O email informado já está cadastrado, tente outro." });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = e.Message });
            }
        }
    }
}

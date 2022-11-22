using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaProfissionais.Api.Model;
using SistemaProfissionais.Api.Security;
using SistemaProfissionais.Domain.Interfaces.Services;
using SistemaProfissionais.Infra.Data.Helper;

namespace SistemaProfissionais.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioDomainService _usuarioDomainService;

        public LoginController(IUsuarioDomainService usuarioDomainService)
        {
            _usuarioDomainService = usuarioDomainService;
        }

        [HttpPost]
        public IActionResult Post(LoginModel model)
        {
            try
            {
                var usuario = _usuarioDomainService.ObterEmailAndSenha(model.Email, MD5Helper.Encrypt(model.Senha));

                if (usuario == null)
                {
                    return StatusCode(400, new { mensagem = "Acesso negado, Usuário inválido." });
                }
                var token = JwtSecurity.GenerateToken(usuario.Email);

                return StatusCode(200, new {mensagem = "Autenticação realizada com sucesso", token });

            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = "Usuario não cadastrado." });
            }
        }


    }
    
}

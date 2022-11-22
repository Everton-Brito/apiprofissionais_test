using System.ComponentModel.DataAnnotations;

namespace SistemaProfissionais.Api.Model
{
    public class UsuariosModel
    {
        [MinLength(6, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Por favor, informe o máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do usuário.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome do usuário.")]
        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor, informe a senha do usuário.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Por favor, confirme a senha do usuário.")]
        [Compare("Senha", ErrorMessage = "Senhas não conferem.")]
        public string SenhaConfirmacao { get; set; }

        public DateTime DataCadastro { get; set; }
    }

    public class StrongPassword : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
           if (value != null)
            {
                var senha = value.ToString();

                return senha.Length >= 8
                    && senha.Length <= 20
                    && senha.Any(char.IsUpper)
                    && senha.Any(char.IsLower)
                    && senha.Any(char.IsDigit)
                    && (senha.Contains("@") ||
                        senha.Contains("#") ||
                        senha.Contains("$") ||
                        senha.Contains("%") ||
                        senha.Contains("&") ||
                        senha.Contains("!") 
                        );
            }

           return false;
        }
    }
}

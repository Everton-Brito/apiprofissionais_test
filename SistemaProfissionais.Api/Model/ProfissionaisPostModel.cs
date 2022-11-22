using System.ComponentModel.DataAnnotations;

namespace SistemaProfissionais.Api.Model
{
    public class ProfissionaisPostModel
    {
        [Required(ErrorMessage = "Por favor, informe o nome do profissional.")]
        [MinLength(6, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe o email do profissional.")]
        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor, informe o cpf do profissional.")]
        [RegularExpression("^[0-9]{11}$", ErrorMessage = "Por favor, informe 11 dígitos numéricos.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Por favor, informe o telefone do profissional.")]
        [RegularExpression("^[0-9]{11}$", ErrorMessage = "Por favor, informe 11 dígitos numéricos.")]
        public string Telefone { get; set; }
    }
}

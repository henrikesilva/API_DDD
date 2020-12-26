using System.ComponentModel.DataAnnotations;

namespace API.Domain.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email é um campo obrigatório para Login.")]
        [EmailAddress(ErrorMessage = "Email m formato inválido.")]
        [StringLength(100, ErrorMessage = "Email deve ter no máximo {1} caracteres.")]
        public string Email { get; set; }
    }
}

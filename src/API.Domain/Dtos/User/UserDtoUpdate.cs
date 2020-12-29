using System;
using System.ComponentModel.DataAnnotations;

namespace API.Domain.Dtos.User
{
    public class UserDtoUpdate
    {
        [Required(ErrorMessage = "Id é um campo obrigatorio")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nome é um campo obrigatorio")]
        [StringLength(60, ErrorMessage = "Nome deve ter no maximo {1} caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email é um campo obrigatorio")]
        [EmailAddress(ErrorMessage = "Email em formato invalido")]
        [StringLength(100, ErrorMessage = "Nome deve ter no maximo {1} caracteres.")]
        public string Email { get; set; }
    }
}

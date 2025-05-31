using System.ComponentModel.DataAnnotations;

namespace KiraShopApi.Dtos.Usuario
{
    public class CreateUsuarioDto
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "CPF deve ter 11 caracteres.")]
        public string CPF { get; set; }

        [Required]
        public bool Tipo { get; set; }
    }

    public class UpdateUsuarioDto
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        // Senha pode ser opcional na atualização, depende do seu fluxo
        public string Senha { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "CPF deve ter 11 caracteres.")]
        public string CPF { get; set; }

        [Required]
        public bool Tipo { get; set; }
    }

    public class ReadUsuarioDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string CPF { get; set; }

        public bool Tipo { get; set; }
    }
}

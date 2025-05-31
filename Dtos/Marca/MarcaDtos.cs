using System.ComponentModel.DataAnnotations;

namespace KiraShopApi.Dtos.Marca
{
    public class CreateMarcaDto
    {
        [Required]
        public string Nome { get; set; } = string.Empty;
    }

    public class ReadMarcaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
    }

    public class UpdateMarcaDto
    {
        [Required]
        public string Nome { get; set; } = string.Empty;
    }
}
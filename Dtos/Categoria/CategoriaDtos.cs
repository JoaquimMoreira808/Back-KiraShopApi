using System.ComponentModel.DataAnnotations;

namespace KiraShopApi.Dtos.Categoria
{
    public class CreateCategoriaDto
    {
        [Required]
        public string Nome { get; set; }
    }

    public class UpdateCategoriaDto
    {
        [Required]
        public string Nome { get; set; }
    }

    public class ReadCategoriaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}

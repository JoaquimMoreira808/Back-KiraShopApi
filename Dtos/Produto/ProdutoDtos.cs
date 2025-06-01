using System.ComponentModel.DataAnnotations;

namespace KiraShopApi.Dtos.Produto
{
    public class ReadProdutoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Descricao { get; set; }
        public int MarcaId { get; set; }
        public string ImagemUrl { get; set; }
        public List<int> CategoriaIds { get; set; }
    }

    public class CreateProdutoDto
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public decimal Preco { get; set; }

        public string Descricao { get; set; }

        [Required]
        public int MarcaId { get; set; }

        public string ImagemUrl { get; set; }

        public List<int> CategoriaIds { get; set; } = new();
    }

    public class UpdateProdutoDto
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public decimal Preco { get; set; }

        public string Descricao { get; set; }

        [Required]
        public int MarcaId { get; set; }

        public string ImagemUrl { get; set; }

        public List<int> CategoriaIds { get; set; } = new();
    }
}
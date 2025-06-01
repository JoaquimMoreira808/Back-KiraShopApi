using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace KiraShopApi.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Descricao { get; set; }
        public int MarcaId { get; set; }
        public string ImagemUrl { get; set; }
        public ICollection<Categoria> Categorias { get; set; } = new List<Categoria>();

        [JsonIgnore]
        public Marca Marca { get; set; }
    }
}

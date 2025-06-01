using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace KiraShopApi.Models
{
    public class Marca
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
    }
}

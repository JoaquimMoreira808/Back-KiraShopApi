using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace KiraShopApi.Models
{
    public class Carrinho
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        [JsonIgnore]
        public ICollection<Produto> Produtos { get; set; }
    }
}

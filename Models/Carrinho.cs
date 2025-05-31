using System.ComponentModel.DataAnnotations;

namespace KiraShopApi.Models
{
    public class Carrinho
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public ICollection<Produto> Produtos { get; set; }
    }
}

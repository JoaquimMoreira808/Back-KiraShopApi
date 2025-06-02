
using System.ComponentModel.DataAnnotations;
using KiraShopApi.Dtos.Produto;

namespace KiraShopApi.Dtos.Carrinho
{
    public class ReadCarrinhoDto
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string UsuarioNome { get; set; }
        public List<ReadProdutoDto> Produtos { get; set; } = new();
    }
}

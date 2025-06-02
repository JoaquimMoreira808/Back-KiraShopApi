
using System.ComponentModel.DataAnnotations;
using KiraShopApi.Dtos.Produto;

namespace KiraShopApi.Dtos.Carrinho
{
    public class UpdateCarrinhoDto
    {
        public List<int> ProdutoIds { get; set; } = new();
    }

}

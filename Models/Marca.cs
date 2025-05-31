﻿using System.ComponentModel.DataAnnotations;

namespace KiraShopApi.Models
{
    public class Marca
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        public ICollection<Produto> Produtos { get; set; }
    }
}

﻿using System.ComponentModel.DataAnnotations;

namespace KiraShopApi.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public bool Tipo { get; set; }

        public Carrinho Carrinho { get; set; }
    }
}

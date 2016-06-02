using Daddato.Lojavirtual.Web.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Daddato.Lojavirtual.Web.Models
{
    public class CarrinhoViewModel
    {
        public string ReturnUrl { get; set; }
        public Carrinho Carrinho { get; set; }
    }
}
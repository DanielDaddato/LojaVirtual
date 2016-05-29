using Daddato.Lojavirtual.Web.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Daddato.Lojavirtual.Web.Models
{
    public class ProdutosViewModel
    {
        public IEnumerable<Produto> Produtos { get; set; }

        public Paginacao Paginacao { get; set; }

        public string CategoriaAtual { get; set; }
    }
}
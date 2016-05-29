using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Daddato.Lojavirtual.Web.Entidades
{
    public class Carrinho
    {
        private readonly List<ItemCarrinho> _itensCarrinho = new List<ItemCarrinho>();

        public void AdicionarItem(Produto produto, int quantidade)
        {
           var item = _itensCarrinho.FirstOrDefault(i => i.Produto.ProdutoId == produto.ProdutoId);
            if (item == null)
            {
                _itensCarrinho.Add(new ItemCarrinho
                {
                    Produto = produto,
                    Quantidade = quantidade,

                });
            }
            else
                item.Quantidade += quantidade;
        }

        public void RemoverItem(Produto produto)
        {
            _itensCarrinho.RemoveAll(i => i.Produto.ProdutoId == produto.ProdutoId);
        }

        public void ValorTotal()
        {
            _itensCarrinho.Sum(i => i.Produto.Preco * i.Quantidade);
        }

        public void LimparCarrinho()
        {
            _itensCarrinho.Clear();
        }

        public IEnumerable<ItemCarrinho> ItemCarrinho { get { return _itensCarrinho; } } 

    }

    public class ItemCarrinho
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
    }
}
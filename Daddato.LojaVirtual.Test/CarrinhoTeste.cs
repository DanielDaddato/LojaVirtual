using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Daddato.Lojavirtual.Web.Entidades;

namespace Daddato.LojaVirtual.Test
{
    [TestClass]
    public class CarrinhoTeste
    {
        [TestMethod]
        public void AdicionaItensTeste()
        {
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Produto 1"
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Produto 2"
            };

            Produto produto3 = new Produto
            {
                ProdutoId = 3,
                Nome = "Produto 3"
            };

            var carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 2);
            carrinho.AdicionarItem(produto3, 3);
            List<ItemCarrinho> resultado = carrinho.ItemCarrinho.ToList();

            Assert.AreEqual(resultado[0].Produto, produto1);
            Assert.AreEqual(resultado[1].Produto, produto2);
            Assert.AreEqual(resultado[2].Produto, produto3);

            Assert.AreEqual(resultado.Count(), 3);

        }

        [TestMethod]
        public void RemoveItem()
        {
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Produto 1"
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Produto 2"
            };

            Produto produto3 = new Produto
            {
                ProdutoId = 3,
                Nome = "Produto 3"
            };

            var carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 2);
            carrinho.AdicionarItem(produto3, 3);
            carrinho.RemoverItem(produto3);
            var resultado = carrinho.ItemCarrinho.ToList().Count;
            Assert.AreEqual(resultado, 2);
        }

        [TestMethod]
        public void AdicionarQuantidade()
        {
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Produto 1"
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Produto 2"
            };

            Produto produto3 = new Produto
            {
                ProdutoId = 3,
                Nome = "Produto 3"
            };

            var carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 2);
            carrinho.AdicionarItem(produto3, 3);
            carrinho.AdicionarItem(produto1, 3);
            carrinho.AdicionarItem(produto2, 2);
            carrinho.AdicionarItem(produto3, 1);
            var resultado = carrinho.ItemCarrinho.ToList();
            Assert.AreEqual(resultado.Count, 3);
            Assert.AreEqual(resultado[0].Quantidade, 4);
            Assert.AreEqual(resultado[1].Quantidade, 4);
            Assert.AreEqual(resultado[2].Quantidade, 4);

        }



        [TestMethod]
        public void SomaItens()
        {
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Produto 1",
                Preco = 100M
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Produto 2",
                Preco= 50M
            };

            Produto produto3 = new Produto
            {
                ProdutoId = 3,
                Nome = "Produto 3",
                Preco = 10M
            };

            var carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 2);
            carrinho.AdicionarItem(produto3, 3);
            carrinho.AdicionarItem(produto1, 2);
            var resultado = carrinho.ValorTotal();
            Assert.AreEqual(resultado, 430M);
        }

        [TestMethod]
        public void LimpaCarrinho()
        {
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Produto 1",
                Preco = 100M
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Produto 2",
                Preco = 50M
            };

            Produto produto3 = new Produto
            {
                ProdutoId = 3,
                Nome = "Produto 3",
                Preco = 10M
            };

            var carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 2);
            carrinho.AdicionarItem(produto3, 3);
            carrinho.AdicionarItem(produto1, 2);
            carrinho.LimparCarrinho();
            var resultado = carrinho.ItemCarrinho;
            Assert.AreEqual(resultado.Count(),0);
        }


    }
}

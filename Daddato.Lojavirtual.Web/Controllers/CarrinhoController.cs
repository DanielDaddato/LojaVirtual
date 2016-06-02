using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Daddato.Lojavirtual.Web.Entidades;
using Daddato.Lojavirtual.Web.Repositorio;
using Daddato.Lojavirtual.Web.Models;

namespace Daddato.Lojavirtual.Web.Controllers
{
    public class CarrinhoController : Controller
    {
        private ProdutosRepositorio _repositorio; 

        public RedirectToRouteResult Adicionar(int produtoId, string returnUrl )
        {
                _repositorio = new ProdutosRepositorio();

                var produto = _repositorio.Produtos.FirstOrDefault(x => x.ProdutoId == produtoId);
                if (produto != null)
                {
                    ObterCarrinho().AdicionarItem(produto, 1);
                }
                return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult Remover(int produtoId, string returnUrl)
        {
            _repositorio = new ProdutosRepositorio();
            var produto = _repositorio.Produtos.FirstOrDefault(x => x.ProdutoId == produtoId);
            if (produto != null)
            {
                ObterCarrinho().RemoverItem(produto);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CarrinhoViewModel
            {
                ReturnUrl = returnUrl,
                Carrinho = ObterCarrinho()
            });
        }
        public PartialViewResult Resumo(string returnUrl)
        {
            var carrinho = ObterCarrinho();
            return PartialView(carrinho);
        }

        private Carrinho ObterCarrinho()
        {
            var carrinho = (Carrinho)Session["Carrinho"];
            if (carrinho == null)
            {
                carrinho = new Carrinho();
                Session["Carrinho"] = carrinho;
            }
            return carrinho;
        }
    }
}
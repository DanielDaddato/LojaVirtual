using Daddato.Lojavirtual.Web.Models;
using Daddato.Lojavirtual.Web.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Daddato.Lojavirtual.Web.Controllers
{
    public class VitrineController : Controller
    {

        int produtosPorPagina = 10;
        // GET: Vitrine
        public ActionResult Index(int pagina = 1)
        {

            var produtos = new ProdutosRepositorio().Produtos.Skip((pagina - 1) * produtosPorPagina)
                .Take(produtosPorPagina);
            return View(produtos);
        }

        public ViewResult ListaProdutos(string categoria, int pagina = 1)
        {
            var _repositorio = new ProdutosRepositorio();


            var produtos = new ProdutosViewModel
            {
                Produtos = _repositorio.Produtos
                .Where(p => categoria == null || p.Categoria == categoria)
                .Skip((pagina - 1) * produtosPorPagina)
                .Take(produtosPorPagina),
                Paginacao = new Paginacao
                {
                    ItensPorPagina = 10,
                    PaginaAtual = pagina,
                    ItensTotal = categoria == null ? _repositorio.Produtos.Count() : _repositorio.Produtos.Where(x => x.Categoria == categoria).Count()
                },
                CategoriaAtual = categoria
            };
            return View(produtos);
        }
    }
}
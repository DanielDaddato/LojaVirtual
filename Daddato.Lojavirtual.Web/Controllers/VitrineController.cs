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

        public ViewResult ListaProdutos(int pagina = 1)
        {
            var _repositorio = new ProdutosRepositorio();
          

            var produtos = new ProdutosViewModel
            {
                Produtos = _repositorio.Produtos
                .Skip((pagina - 1) * produtosPorPagina)
                .Take(produtosPorPagina),
                Paginacao = new Paginacao
                {
                    ItensPorPagina = 10,
                    PaginaAtual = pagina,
                    ItensTotal = _repositorio.Produtos.Count()
                }
            };
            return View(produtos);
        }
    }
}
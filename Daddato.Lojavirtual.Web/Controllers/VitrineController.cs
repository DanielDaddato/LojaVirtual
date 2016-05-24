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
    }
}
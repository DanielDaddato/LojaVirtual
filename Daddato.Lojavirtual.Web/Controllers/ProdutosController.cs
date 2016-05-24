using Daddato.Lojavirtual.Web.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Daddato.Lojavirtual.Web.Controllers
{
    public class ProdutosController : Controller
    {
        // GET: Produtos
        public ActionResult Index()
        {
            var produtos = new ProdutosRepositorio().Produtos;
            return View(produtos);
        }
    }
}
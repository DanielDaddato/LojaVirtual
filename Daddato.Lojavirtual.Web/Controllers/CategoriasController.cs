using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Daddato.Lojavirtual.Web.Controllers
{
    public class CategoriasController : Controller
    {
        // GET: Categorias
        public PartialViewResult Menu(string categoria = null)
        {
            ViewBag.CategoriaSelecionada = categoria;

            var categorias = new Repositorio.ProdutosRepositorio()
                .Produtos.Select(x => x.Categoria).Distinct().OrderBy(x => x);
            return PartialView(categorias);
        }
    }
}
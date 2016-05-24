using Daddato.Lojavirtual.Web.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daddato.Lojavirtual.Web.Repositorio
{
    public class ProdutosRepositorio
    {
        private readonly LojaVirtualContext _lojaVirtualContext = new LojaVirtualContext();
        public IEnumerable<Produto> Produtos
        {
            get { return _lojaVirtualContext.Produtos; }
        }
    }
}

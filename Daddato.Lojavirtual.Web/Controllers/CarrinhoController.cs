using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Daddato.Lojavirtual.Web.Entidades;
using Daddato.Lojavirtual.Web.Repositorio;
using Daddato.Lojavirtual.Web.Models;
using RestSharp;
using RestSharp.Serializers;
using RestSharp.Deserializers;
using System.Configuration;

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

        public ViewResult FecharPedido()
        {
            return View(new Pedido());
        }

        [HttpPost]
        public ViewResult FecharPedido(Pedido pedido)
        {
            var carrinho = ObterCarrinho();
            var emailConfiguracoes = new EmailConfiguracoes
            {
                SSL = false,
                De = "Loja@lojavirtual.com",
                Para = pedido.Email,
                Sevidor = "www.lojavirtual.com",
                EscreverArquivo = bool.Parse(ConfigurationManager.AppSettings["email.EscreverArquivo"]),
                PastaArquivo = @"C:\emails",
                Usuario = "daddato@lojavirtual.com",
                Password = "12345",
                Porta = 554
            };

            var emailPedido = new EmailPedido(emailConfiguracoes);

            if (!carrinho.ItemCarrinho.Any())
            {
                ModelState.AddModelError("", "Não foi possivel fechar o pedido, não há itens no carrinho");
            }

            if (ModelState.IsValid)
            {
                emailPedido.ProcessaPedido(carrinho, pedido);
                carrinho.LimparCarrinho();
                return View("PedidoConcluido");
            }
            else
            {
                return View(new Pedido());
            }
        }

        public ViewResult PedidoConcluido()
        {
            return View();
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

        public JsonResult ConsultaCEP(string CEP)
        {
            var client = new RestClient("http://www.devmedia.com.br/devware/cep/service/");
            var request = new RestRequest(Method.GET);
            request.AddParameter("cep", CEP);
            request.AddParameter("chave", "92Q1QOZ2NF");
            request.AddParameter("formato", "json");
            var resposta = client.Execute(request);
            
            return Json(resposta.Content,JsonRequestBehavior.AllowGet);

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Daddato.Lojavirtual.Web.Entidades
{
    public class EmailPedido
    {
        private EmailConfiguracoes _emailConfiguracoes;

        public EmailPedido(EmailConfiguracoes emailConfiguracoes)
        {
            _emailConfiguracoes = emailConfiguracoes;
        }

        public void ProcessaPedido(Carrinho carrinho, Pedido pedido)
        {
            using (SmtpClient smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = _emailConfiguracoes.SSL;
                smtpClient.Host = _emailConfiguracoes.Sevidor;
                smtpClient.Port = _emailConfiguracoes.Porta;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(_emailConfiguracoes.Usuario, _emailConfiguracoes.Password);

                if (_emailConfiguracoes.EscreverArquivo)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = _emailConfiguracoes.PastaArquivo;
                    smtpClient.EnableSsl = false;
                }

                StringBuilder body = new StringBuilder()
                .AppendLine("Novo Pedido")
                .AppendLine("------------------")
                .AppendLine("Itens");

                foreach (var item in carrinho.ItemCarrinho)
                {
                    var subtotal = (item.Quantidade * item.Produto.Preco);
                    body.AppendFormat("{0} x {1} - Subtotal :{2:c}", item.Quantidade, item.Produto, subtotal);
                }

                body.AppendFormat("Valor Total do Pedido : {0:c}", carrinho.ValorTotal());
                body.AppendLine("-----------------");
                body.AppendLine("Dados de Envio:")
                .AppendLine(pedido.NomeCliente)
                .AppendLine(pedido.Email)
                .AppendLine(pedido.Endereco + "," + pedido.Numero)
                .AppendLine(pedido.Complemento ?? "")
                .AppendLine(pedido.Bairro)
                .AppendLine(pedido.Cidade)
                .AppendLine(pedido.Cep)
                .AppendLine(pedido.UF)
                .AppendLine("----------------")
                .AppendFormat("Para Presente? {0}", pedido.EmbrulharPresente ? "Sim" : "Não");

                MailMessage mailMessage = new MailMessage(
                    _emailConfiguracoes.De,
                    _emailConfiguracoes.Para,
                    "Novo Pedido",
                    body.ToString());

                if (_emailConfiguracoes.EscreverArquivo)
                {
                    mailMessage.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");

                }
                smtpClient.Send(mailMessage);
            }
        }
    }
}

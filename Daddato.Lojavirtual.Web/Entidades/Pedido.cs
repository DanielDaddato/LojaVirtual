using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Daddato.Lojavirtual.Web.Entidades
{
    public class Pedido
    {
        [Required(ErrorMessage = "Favor preencher Nome")]
        [Display(Name = "Nome do Cliente")]
        public string NomeCliente { get; set; }

        [Required(ErrorMessage = "Favor Preencher E-mail")]
        [EmailAddress]
        [Display(Name = "E-mail:")]
        public string Email { get; set; }
        [Phone]
        [Display(Name ="Telefone:")]
        public string Telefone { get; set; }

        [Display(Name ="CEP:", Prompt ="Digite apenas numeros")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Favor preencher endereço")]
        [Display(Name = "Endereço:")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Favor preencher numero")]
        [Display(Name = "Numero:")]
        public int Numero { get; set; }

        [Display(Name = "Complemento:")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Favor preencher bairro")]
        [Display(Name = "Bairro:")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Favor preencher cidade")]
        [Display(Name = "Cidade:")]
        public string Cidade { get; set; }

        [Required(ErrorMessage ="Favor preencher UF")]
        [Display(Name = "UF:")]
        public string UF { get; set; }

        public bool EmbrulharPresente { get; set; }
    }
}
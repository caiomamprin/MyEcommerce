using Ecommerce.Libraries.Lang;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessageResourceType = typeof(ReturnMessage), ErrorMessageResourceName = "MSG_BAD001")]
        [MinLength(3, ErrorMessageResourceType = typeof(ReturnMessage), ErrorMessageResourceName = "MSG_BAD002")]
        public string Name { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessageResourceType = typeof(ReturnMessage), ErrorMessageResourceName = "MSG_BAD001")]
        [MinLength(10, ErrorMessageResourceType = typeof(ReturnMessage), ErrorMessageResourceName = "MSG_BAD002")]
        public string Birthday { get; set; }

        [Display(Name = "Sexo")]
        [Required(ErrorMessageResourceType = typeof(ReturnMessage), ErrorMessageResourceName = "MSG_BAD001")]
        public string Sex { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(ReturnMessage), ErrorMessageResourceName = "MSG_BAD001")]
        [MinLength(14, ErrorMessageResourceType = typeof(ReturnMessage), ErrorMessageResourceName = "MSG_BAD002")]
        public string CPF { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessageResourceType = typeof(ReturnMessage), ErrorMessageResourceName = "MSG_BAD001")]
        public string NumberPhone { get; set; }

        [Required(ErrorMessageResourceType = typeof(ReturnMessage), ErrorMessageResourceName = "MSG_BAD001")]
        [EmailAddress(ErrorMessageResourceType = typeof(ReturnMessage), ErrorMessageResourceName = "MSG_BAD004")]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessageResourceType = typeof(ReturnMessage), ErrorMessageResourceName = "MSG_BAD001")]
        public string Password { get; set; }

    }
}

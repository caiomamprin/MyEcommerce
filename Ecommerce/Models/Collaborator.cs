using Ecommerce.Libraries.Lang;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class Collaborator
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessageResourceType = typeof(ReturnMessage), ErrorMessageResourceName = "MSG_BAD001")]
        [MinLength(3, ErrorMessageResourceType = typeof(ReturnMessage), ErrorMessageResourceName = "MSG_BAD002")]
        public string Name { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(ReturnMessage), ErrorMessageResourceName = "MSG_BAD001")]
        [EmailAddress(ErrorMessageResourceType = typeof(ReturnMessage), ErrorMessageResourceName = "MSG_BAD004")]
        public string Email { get; set; }
        
        [Display(Name = "Senha")]
        [Required(ErrorMessageResourceType = typeof(ReturnMessage), ErrorMessageResourceName = "MSG_BAD001")]
        public string Password { get; set; }
        
        [NotMapped]
        [Display(Name = "Confirme a senha")]
        [Compare("Password", ErrorMessageResourceType = typeof(ReturnMessage), ErrorMessageResourceName = "MSG_BAD005")]
        public string ConfirmPassword { get; set; }
        
        //M = MANAGER / N = NORMAL 
        public string Type { get; set; }
        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Libraries.Lang;
namespace Ecommerce.Models
{
    public class Contact
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessageResourceType = typeof(ReturnMessage), ErrorMessageResourceName = "MSG_BAD001" )]
        [MinLength(3, ErrorMessageResourceType = typeof(ReturnMessage), ErrorMessageResourceName = "MSG_BAD002")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(ReturnMessage), ErrorMessageResourceName = "MSG_BAD001")]
        [EmailAddress(ErrorMessageResourceType = typeof(ReturnMessage), ErrorMessageResourceName = "MSG_BAD004")]
        public string Email { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(ReturnMessage), ErrorMessageResourceName = "MSG_BAD001")]
        [MinLength(15, ErrorMessageResourceType = typeof(ReturnMessage), ErrorMessageResourceName = "MSG_BAD002")]
        [MaxLength(500, ErrorMessageResourceType = typeof(ReturnMessage), ErrorMessageResourceName = "MSG_BAD003")]
        public string Message { get; set; }
    }
}

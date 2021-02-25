using Ecommerce.Libraries.Lang;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class NewsletterEmail
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(ReturnMessage), ErrorMessageResourceName = "MSG_BAD001")]
        [EmailAddress(ErrorMessageResourceType = typeof(ReturnMessage), ErrorMessageResourceName = "MSG_BAD004")]
        public string Email { get; set; }
    }
}

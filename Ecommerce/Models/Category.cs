using Ecommerce.Libraries.Lang;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class Category
    {
        public int Id { get; set; }
        
        [Display(Name = "Nome")]
        [Required(ErrorMessageResourceType = typeof(ReturnMessage), ErrorMessageResourceName = "MSG_BAD001")]
        [MinLength(3, ErrorMessageResourceType = typeof(ReturnMessage), ErrorMessageResourceName = "MSG_BAD002")]
        //TODO - Criar validação - Nome unico no BD
        public string Name { get; set; }

        /*
         *  Example Slug: www.loja.com/category/1 TO www.loja.com/category/shoes
         */
        [Required(ErrorMessageResourceType = typeof(ReturnMessage), ErrorMessageResourceName = "MSG_BAD001")]
        [MinLength(3, ErrorMessageResourceType = typeof(ReturnMessage), ErrorMessageResourceName = "MSG_BAD002")]
        public string Slug { get; set; }

        [Display(Name = "Categoria Pai")]
        public int? CategoryFatherId { get; set; }
        
        [ForeignKey("CategoryFatherId")]
        public virtual Category CategoryFather { get; set; }


    }
}

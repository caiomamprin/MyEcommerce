using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        /*
         *  Example Slug: www.loja.com/category/1 TO www.loja.com/category/shoes
         */
        public string Slug { get; set; }
        public int? CategoryFatherId { get; set; }
        
        [ForeignKey("CategoryFatherId")]
        public virtual Category CategoryFather { get; set; }


    }
}

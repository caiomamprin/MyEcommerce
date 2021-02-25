using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{ 
    public class ProdutoController : Controller
    {
        public ActionResult Visualizar()
        {
            Produto produto = GetProduto();
            return View(produto);
            //return new ContentResult () {Content = "Teste", ContentType = "text/html" };
        }
    private Produto GetProduto()
    {
        return new Produto() 
        {
            Id = 1,
            Nome = "Iphone X",
            Descricao = "Iphone 256G",
            Valor = 5000.00M
        };

    }
    }

}

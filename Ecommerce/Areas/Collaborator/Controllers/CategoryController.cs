using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Libraries.Filter;
using Ecommerce.Models;
using Ecommerce.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Areas.Collaborator.Controllers
{
    [Area("Collaborator")]
    //TODO - Implementar Verificacao Login
    //[CollaboratorAuth]
    public class CategoryController : Controller
    {

        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Category> categories = _categoryRepository.GetAllCategory().ToList();
            return View(categories);
        }

        [HttpPost]
        public IActionResult SetCategory([FromForm] Category category)
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateCategory([FromForm] Category category)
        {
            return View();
        }

        [HttpPost]
        public IActionResult DeleteCategory(int id)
        {
            return View();
        }
    }
}
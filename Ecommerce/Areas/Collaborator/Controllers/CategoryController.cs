using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Libraries.Filter;
using Ecommerce.Models;
using Ecommerce.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce.Areas.Collaborator.Controllers
{
    [Area("Collaborator")]
    //TODO - Implementar Verificacao Login
    //[C'ollaboratorAuth]
    public class CategoryController : Controller
    {

        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult Index(int? pageIndex)
        {
            var categories = _categoryRepository.GetAllCategory(pageIndex);
            return View(categories);
        }

        [HttpGet]
        public IActionResult RegisterCategory()
        {
            ViewBag.Categories = _categoryRepository.GetAllCategory().Select(a => new SelectListItem(a.Name, a.Id.ToString()));
            return View();
        }

        [HttpPost]
        public IActionResult RegisterCategory([FromForm] Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.SetCategory(category);
                
                TempData["MSG_OK"] = "Categoria Cadastrada com sucesso!";

                ViewBag.Categories = _categoryRepository.GetAllCategory().Select(a => new SelectListItem(a.Name, a.Id.ToString()));

                return RedirectToAction(nameof(Index));
            }
            
            return View();
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            Category categoria = _categoryRepository.GetCategoryById(id);
            ViewBag.Categories = _categoryRepository.GetAllCategory().Where(a => a.Id != id).Select(a => new SelectListItem(a.Name, a.Id.ToString()));
            return View(categoria);
        }

        [HttpPost]
        public IActionResult UpdateCategory([FromForm]Category category, int id)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.UpdateCategory(category);
                TempData["MSG_OK"] = "Categoria Alterada com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = _categoryRepository.GetAllCategory().Where(a => a.Id != id).Select(a => new SelectListItem(a.Name, a.Id.ToString()));
            return View();
        }

        [HttpGet]
        public IActionResult DeleteCategory(int id)
        {
            _categoryRepository.DeleteCategory(id);
            TempData["MSG_OK"] = "Categoria Alterada com sucesso!";
            return RedirectToAction(nameof(Index));

        }
    }
}
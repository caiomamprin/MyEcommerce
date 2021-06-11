using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Libraries.Filter;
using Ecommerce.Libraries.Login;
using Ecommerce.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Areas.Collaborator.Controllers
{
    [Area("Collaborator")]
    public class HomeController : Controller
    {

        private readonly ICollaboratorRepository _categoryRepository;
        private readonly LoginCollaborator _loginCollaborator;
        public HomeController(ICollaboratorRepository categoryRepository, LoginCollaborator loginCollaborator)
        {
            _categoryRepository = categoryRepository;
            _loginCollaborator = loginCollaborator;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login([FromForm]Models.Collaborator collaborator) 
        {
            Models.Collaborator collaboratorDB= _categoryRepository.Login(collaborator.Email, collaborator.Password);

            if (collaboratorDB != null)
            {
                _loginCollaborator.LoginSession(collaborator);
                return new RedirectResult(Url.Action(nameof(Dashboard)));

            }
            ViewData["MSG_BAD"] = "Usuário não encontrado, verifique o email e senha digitados.";
            return View();
        }

        [CollaboratorAuth]
        public IActionResult Logout()
        {
            _loginCollaborator.Logout();
            return RedirectToAction("Login", "Home");
        }

        public IActionResult RecoverPassword()
        {
            return View();
        }

        public IActionResult RegisterNewPassword()
        {
            return View();
        }

        [CollaboratorAuth]
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
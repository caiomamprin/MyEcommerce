using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Libraries.Login;
using Ecommerce.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Areas.Collaborator.Controllers
{
    [Area("Collaborator")]
    public class HomeController : Controller
    {

        private readonly ICollaboratorRepository _collaboratorRepository;
        private readonly LoginCollaborator _loginCollaborator;
        public HomeController(ICollaboratorRepository collaboratorRepository, LoginCollaborator loginCollaborator)
        {
            _collaboratorRepository = collaboratorRepository;
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
            Models.Collaborator collaboratorDB= _collaboratorRepository.Login(collaborator.Email, collaborator.Password);

            if (collaboratorDB != null)
            {
                _loginCollaborator.LoginSession(collaborator);
                return new RedirectResult(Url.Action(nameof(Painel)));

            }
            ViewData["MSG_BAD"] = "Usuário não encontrado, verifique o email e senha digitados.";
            return View();
        }

        private object Painel()
        {
            throw new NotImplementedException();
        }

        public IActionResult RecoverPassword()
        {
            return View();
        }

        public IActionResult RegisterNewPassword()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Libraries.Generator;
using Ecommerce.Repositories;
using Ecommerce.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Areas.Collaborator.Controllers
{
    [Area("Collaborator")]
    public class CollaboratorController : Controller
    {

        private readonly ICollaboratorRepository _collaboratorRepository;

        public CollaboratorController(ICollaboratorRepository collaboratorRepository)
        {
            _collaboratorRepository = collaboratorRepository;
        }

        [HttpGet]
        public IActionResult Index(int? pageIndex)
        {
            var collaborators = _collaboratorRepository.GetAllCollaborator(pageIndex);
            return View(collaborators);
        }

        [HttpGet]
        public IActionResult RegisterCollaborator()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterCollaborator([FromForm]Models.Collaborator collaborator)
        {
            if (ModelState.IsValid)
            {
                _collaboratorRepository.RegisterCollaborator(collaborator);
                TempData["MSG_OK"] = "Colaborador cadastrado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult UpdateCollaborator(int id)
        {
            Models.Collaborator collaborator = _collaboratorRepository.getCollaboratorById(id);
            return View(collaborator);
        }

        [HttpPost]
        public IActionResult UpdateCollaborator([FromForm]Models.Collaborator collaborator, int id)
        {
            if (ModelState.IsValid)
            {
                _collaboratorRepository.UpdateCollaborator(collaborator);
                TempData["MSG_OK"] = "Colaborador Alterado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult DeleteCollaborator(int id)
        {
            _collaboratorRepository.DeleteCollaborator(id);
            TempData["MSG_OK"] = "Colaborador excluído com sucesso!";
            return RedirectToAction(nameof(Index));
            
        }

        [HttpGet]
        public IActionResult GeneratorPassword(int id)
        {
            Models.Collaborator collaborator = _collaboratorRepository.getCollaboratorById(id);
            collaborator.Password = KeyGenerator.GetUniqueKey(8);
            _collaboratorRepository.UpdateCollaborator(collaborator);
        }
    }
}
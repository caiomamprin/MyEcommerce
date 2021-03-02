using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Libraries.Email;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Ecommerce.Database;
using Ecommerce.Repositories.Contracts;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommerce.Controllers
{
    public class HomeController : Controller
    {
        private IClientRepository _clientRepository;
        private INewsletterRepository _newsletterRepository;

        public HomeController(IClientRepository clientRepository, INewsletterRepository newsletterRepository)
        {
            _clientRepository = clientRepository;
            _newsletterRepository = newsletterRepository;
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(NewsletterEmail newsletterEmail)
        {
            if (ModelState.IsValid)
            {
                //_newsletterRepository.RegisterNewsletter(newsletterEmail);
                //ViewData["MSG_OK"] = "CADASTROU!";//"Seu Email foi cadastrado!Fique atento para as ofertas imperdíveis.";
                TempData["MSG_S"] = "E-mail cadastrado! Agora você vai receber promoções especiais no seu e-mail! Fique atento as novidades!";

                return RedirectToAction(nameof(Index));
            }
                return View();
            
        }
        public IActionResult Contact()
        {
            return View();
        }


        public IActionResult ContactAction()
        {
            try
            {
                Contact contact = new Contact();
                contact.Name = HttpContext.Request.Form["userName"];
                contact.Email = HttpContext.Request.Form["email"];
                contact.Message = HttpContext.Request.Form["userMessage"];

                var listMessage = new List<ValidationResult>();
                var objContext = new ValidationContext(contact);
                bool isValid = Validator.TryValidateObject(contact, objContext, listMessage, true);

                if (isValid)
                {
                ContactMail.SendUserMail(contact);
                    //ViewData é usado para passar uma informação pra tela
                    TempData["MSG_OK"] = "Seu cadastro foi realizado com sucesso.";
                }
                else
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (var msg in listMessage)
                    {
                        sb.Append(msg.ErrorMessage + "<br />");
                    }
                    ViewData["MSG_BAD"] = sb.ToString();
                    ViewData["CONTACT"] = contact;
                }

            }
            catch (Exception ex)
            {
                ViewData["MSG_BAD"] = "Ops!Tivemos um erro inesperado, tente novamente mais tarde.";
            }
            
            
            return View("Contact");

            //return new ContentResult() { Content = String.Format("User:{0} <br/> Email:{1}) <br/> Message:{2} <br/>", contact.Name, contact.Email, contact.Message) , ContentType="text/html"};
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RegisterCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterCustomer([FromForm] Client client)
        {
            if (ModelState.IsValid)
            {
                //_clientRepository.RegisterClient(client);
                TempData["MSG_OK"] = "Seu cadastro foi realizado com sucesso.";
                RedirectToAction(nameof(RegisterCustomer));
            }
            return View();
        }

        public IActionResult CarrinhoCompras()
        {
            return View();
        }

    }
}

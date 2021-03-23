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
using Microsoft.AspNetCore.Http;
using Ecommerce.Libraries.Login;
using Ecommerce.Libraries.Filter;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClientRepository _clientRepository;
        private readonly INewsletterRepository _newsletterRepository;
        private readonly LoginClient _loginClient;
        
        public HomeController(IClientRepository clientRepository, INewsletterRepository newsletterRepository, LoginClient loginClient)
        {
            _clientRepository = clientRepository;
            _newsletterRepository = newsletterRepository;
            _loginClient = loginClient;
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
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromForm]Client client)
        {

            Client clientDB = _clientRepository.Login(client.Email, client.Password);
            
            if(clientDB != null)
            {
                _loginClient.LoginSession(client);
                return new RedirectResult(Url.Action(nameof(Painel)));
                
            }
            ViewData["MSG_BAD"] = "Usuário não encontrado, verifique o email e senha digitados.";
            return View();
         
        }

        [HttpGet]
        [ClientAuth]
        public IActionResult Painel()
        {
            return new ContentResult() { Content = "Painel do Usuário" };
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
                _clientRepository.RegisterClient(client);
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

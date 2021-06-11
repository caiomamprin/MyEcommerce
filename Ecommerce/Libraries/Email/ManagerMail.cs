using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Ecommerce.Libraries.Email
{
    public class ManagerMail
    {
        public static void SendUserMail(Contact contact)
        {
                /*
             * 
             *  SMTP Server Configuration 
             * 
             * */
             SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
             smtp.UseDefaultCredentials = false;
             smtp.Credentials = new NetworkCredential("caio@signainfo.com.br", "password");
             smtp.EnableSsl = true;

             /*
              * 
              *  Build Message Mail
              * 
              * */

             string bodyMail = string.Format("<h2>Contato - Loja Virtual</h2>" +
                 "<b>Nome: </b> {0} <br />" +
                 "<b>Email: </b> {0} <br />" +
                 "<b>Texto: </b> {0} <br />" +
                 "<br /> E-mail enviado automaticamente do site LojaVirtual",
                 contact.Name, contact.Email, contact.Message);


             MailMessage message = new MailMessage();
             message.From = new MailAddress("caio@signainfo.com.br");
             message.To.Add("caio@signainfo.com.br");
             message.Subject = "Contato Loja Virtual - " + contact.Email;
             message.Body = bodyMail;
             message.IsBodyHtml = true;

             smtp.Send(message);
        }
    }
}

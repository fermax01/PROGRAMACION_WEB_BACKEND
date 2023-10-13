using Microsoft.AspNetCore.Mvc;
using ProgramacionWeb_Backend.Models;
using ProgramacionWeb_Backend.Services;
using System.Net;
using System.Net.Mail;

namespace ProgramacionWeb_Backend.Controllers
{
    public class ContactoController : Controller
    {

        private readonly IEmailSenderService _emailSender;

        public ContactoController(IEmailSenderService emailSender)
        {
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult formulario()
        {
            return View();
        }

        [HttpPost]
        public IActionResult enviaremail(string email,string comentario)
        {

            TempData["Email"]= email;
            TempData["Comentario"]= comentario;
            EnviarEmailSmtp(email);
            return View("index","contacto");
        }


        [HttpPost]
        public IActionResult Enviarformulario(EmailViewModel model )
        {
            TempData["Email"] = model.Email;
            TempData["Comentario"] = model.Mensaje;

            var result =_emailSender.SendEmail(model.Email);
            if (!result)
            {
                TempData["EmailError"] = "ocurrio un error en el email";
            }

            return View("formulario", "model");

            return View();
        }

        public bool EnviarEmailSmtp(string email)
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtp = new SmtpClient("mail.shapp.mx", 587);

            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("moises.puc@shapp.mx", "Dhaserck_999");
            mail.From = new MailAddress("moises.puc@shapp.mx", "Administrador");

            mail.To.Add(email);
            mail.Subject = "aviso de contacto";
            mail.IsBodyHtml = true;

            mail.Body = $"Se ha contactado la persona con el correo {email} para solicitar informacion";
            smtp.Send(mail);
            return true;
        }
    }
}

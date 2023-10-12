using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace ProgramacionWeb_Backend.Controllers
{
    public class ContactoController : Controller
    {
        public IActionResult Index()
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

        public bool EnviarEmailSmtp(string email)
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtpClient = new SmtpClient("mail.shapp.mx",587);

            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials= false;
            smtpClient.Credentials=new NetworkCredential("moises.puc@shapp","Dhaserck_999");

            mail.From = new MailAddress("685ae165283f06@lamasticots.com", "Administrador");
            mail.To.Add(email);
            mail.IsBodyHtml= true;
            mail.Body = $"se ha contactado la persona con el correo{email} para solicitar";
            smtpClient.Send(mail);

            return true;

        }
    }
}

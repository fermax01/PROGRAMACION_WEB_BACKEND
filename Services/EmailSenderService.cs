using System.Net.Mail;
using System.Net;
using ProgramacionWeb_Backend.Models;

namespace ProgramacionWeb_Backend.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        public bool SendEmail(string email)
        {
            bool result = false;
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtp = new SmtpClient("mail.shapp.mx", 587);

                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("moises.puc@shapp.mx", "Dhaserck_999");
                mail.From = new MailAddress("moises.puc@shapp.mx", "Administrador");
                mail.To.Add(email);
                mail.Subject = "Aviso de contacto";
                mail.IsBodyHtml = true;
                mail.Body = $"Se ha contactado la persona con el correo {email} para solicitar informacion";
                smtp.Send(mail);

                result = true;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        public bool ProcesarSolicitud(EmailViewModel model)
        {
            bool result = false;
            try
            {

                MailMessage mail = new MailMessage();
                SmtpClient smtpClient = new SmtpClient("mail.shapp.mx", 587);

                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("moises.puc@shapp.mx", "Dhaserck_999");

                mail.From = new MailAddress("moises.puc@shapp.mx", "Administrador");
                mail.To.Add(model.Email);
                mail.Subject = "Información de contacto: ";
                mail.IsBodyHtml = true;
                mail.Body = $"Se ha contactado el cliente {model.Nombre} {model.Apellido} con los siguientes datos:" +
                    $"Correo: {model.Email} " +
                    $"Turno: {model.Turno} " +
                    $"Mensaje: {model.Mensaje} " +
                    $"Fecha de Nacimiento: {model.FechaNacimiento} " +
                    $"Hora de Entrada: {model.HoraEntrada}";

                smtpClient.Send(mail);

                result = true;
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }
    }
}

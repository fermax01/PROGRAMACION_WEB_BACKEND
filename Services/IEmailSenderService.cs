using ProgramacionWeb_Backend.Models;

namespace ProgramacionWeb_Backend.Services
{
    public interface IEmailSenderService
    {
        bool SendEmail(string email);
        bool ProcesarSolicitud(EmailViewModel model);
    }
}

namespace ProgramacionWeb_Backend.Services
{
    public interface IEmailSenderService
    {
        bool SendEmail(string email);
    }
}

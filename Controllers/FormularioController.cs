using Microsoft.AspNetCore.Mvc;
using ProgramacionWeb_Backend.Services;

namespace ProgramacionWeb_Backend.Controllers
{
    public class FormularioController : Controller
    {
         private readonly IEmailSenderService _emailSender;
        public FormularioController(IEmailSenderService emailSender)
        {
            _emailSender = emailSender;
        }
        public IActionResult Index()
        {
            _emailSender.SendEmail("moise.torres.edu.mx");
            return View();
        }
        

        //public string? Nombre { get; set; }

        //public string? Apellido { get; set; }

        //public string? Curp { get; set; }

        //public DateTime? FechaNacimiento { get; set; }

        //public string? Rfc { get; set; }

        //public string? NombrePuesto { get; set; }
            

    }
}

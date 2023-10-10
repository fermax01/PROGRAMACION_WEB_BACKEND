using Microsoft.AspNetCore.Mvc;
using ProgramacionWeb_Backend.Models;

namespace ProgramacionWeb_Backend.Controllers
{
    public class EjemploController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Texto = "Esto es un texto desde el controlador";
            TempData["Texto2"] = "Esto es un texto temporal";

            Ejemplo model = new Ejemplo();
            model.Titulo = "Esto es un texto desde el controlador";
            model.Parrafo = "Esto es un parrafo";

            return View(model);
        }
        [HttpPost]
        public IActionResult Index(Ejemplo ejemplo) 
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}

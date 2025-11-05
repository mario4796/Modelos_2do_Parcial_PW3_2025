using Microsoft.AspNetCore.Mvc;

namespace SistemaDeJugadores.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

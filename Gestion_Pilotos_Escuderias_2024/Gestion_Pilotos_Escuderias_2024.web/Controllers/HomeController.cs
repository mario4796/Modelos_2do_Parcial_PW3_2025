using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_Pilotos_Escuderias_2024.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

using System.Diagnostics;
using Gestion_de_Reservas.web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_de_Reservas.web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

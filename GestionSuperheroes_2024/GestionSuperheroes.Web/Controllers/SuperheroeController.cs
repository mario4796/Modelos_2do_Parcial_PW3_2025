using GestionSuperheroes.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace GestionSuperheroes.Web.Controllers
{
    public class SuperheroeController : Controller
    {
        private readonly ISuperheroeServicio _superheroeServicio;
        private readonly IUniversoServicio _universoServicio;
        public SuperheroeController(ISuperheroeServicio superheroeServicio, IUniversoServicio universoServicio)
        {
            _superheroeServicio = superheroeServicio;
            _universoServicio = universoServicio;
        }

        [HttpGet]
        public IActionResult AgregarSuperheroe()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ListarSuperheroes()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using SistemaDeJugadores.Servicios;

namespace SistemaDeJugadores.Web.Controllers
{
    public class JugadorController : Controller
    {
        private readonly IJugadorServicio _jugadorServicio;
        private readonly IEquipoServicio _equipoServicio;
        public JugadorController(IEquipoServicio equipoServicio, IJugadorServicio jugadorServicio)
        {
            _equipoServicio = equipoServicio;
            _jugadorServicio = jugadorServicio;
        }

        [HttpGet]
        public IActionResult AgregarJugador()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ListarJugadores()
        {
            return View(); 
        }
    }
}

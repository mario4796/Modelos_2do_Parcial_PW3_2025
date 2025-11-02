using Gestion_Pilotos_Escuderias_2024.Data.EF;
using Gestion_Pilotos_Escuderias_2024.Logica;
using Gestion_Pilotos_Escuderias_2024.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_Pilotos_Escuderias_2024.Web.Controllers
{
    public class PilotoController : Controller
    {
        private readonly IPilotoLogica _pilotoLogica;
        private readonly IEscuderiaLogica _escuderiaLogica;
        public PilotoController(IPilotoLogica pilotoLogica, IEscuderiaLogica escuderiaLogica)
        {
            _pilotoLogica = pilotoLogica;
            _escuderiaLogica = escuderiaLogica;
        }

        [HttpGet]
        public IActionResult AgregarPiloto()
        {
            var escuderias = _escuderiaLogica.ObtenerEscuderias();
            ViewBag.Escuderias = escuderias;

            return View();
        }

        [HttpPost]
        public IActionResult AgregarPiloto(PilotoViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                CargarDropdownEscuderias();
                return View(modelo);
            }

            var escuderia = _escuderiaLogica.ObtenerEscuderiaPorId(modelo.IdEscuderia);
            if (escuderia == null)
            {
                ModelState.AddModelError("IdEscuderia", "La escudería seleccionada no es válida.");

                CargarDropdownEscuderias();
                return View(modelo);
            }

            var pilotoEntidad = new Piloto
            {
                NombrePiloto = modelo.NombrePiloto,
                IdEscuderia = modelo.IdEscuderia,
                Eliminado = false
            };

            _pilotoLogica.AgregarPiloto(pilotoEntidad);
            return RedirectToAction("ListarPilotos");
        }

        private void CargarDropdownEscuderias()
        {
            var escuderias = _escuderiaLogica.ObtenerEscuderias();
            ViewBag.Escuderias = escuderias;
        }

        public IActionResult EliminarPiloto(int id)
        {
            _pilotoLogica.EliminarPiloto(id);
            return RedirectToAction("ListarPilotos");
        }


        [HttpGet]
        public IActionResult ListarPilotos(int? IdEscuderia)
        {
            CargarDropdownEscuderias();
            if (IdEscuderia.HasValue)
            {
                ViewBag.EscuderiaSeleccionada = IdEscuderia.Value;
                return View(_pilotoLogica.ObtenerPilotosPorEscuderia(IdEscuderia.Value));
            }
            else
            {
                return View(_pilotoLogica.ObtnenerTodosLosPilotos());
            }
        }
    }
}

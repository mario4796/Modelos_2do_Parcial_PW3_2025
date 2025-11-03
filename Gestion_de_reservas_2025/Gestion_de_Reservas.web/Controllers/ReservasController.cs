using Gestion_de_Reservas.Data.EF;
using Gestion_de_Reservas.Logica;
using Gestion_de_Reservas.web.Models;
using Microsoft.AspNetCore.Mvc;
using System.ClientModel.Primitives;

namespace Gestion_de_Reservas.web.Controllers
{
    public class ReservasController : Controller
    {
        private readonly IDestinoLogica _destinoLogica;
        private readonly IReservaLogica _reservaLogica;
        public ReservasController(IDestinoLogica destinoLogica, IReservaLogica reservaLogica)
        {
            _destinoLogica = destinoLogica;
            _reservaLogica = reservaLogica;
        }

        [HttpGet]
        public IActionResult Agregar()
        {
            var destinos = _destinoLogica.ObtenerDestinos();
            ViewBag.Destinos = destinos;
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(ReservaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                CargarDropdownDestinos();
                return View(model);
            }

            var destinos = _destinoLogica.ObtenerDestinosPorId(model.IdDestino);
            if (destinos == null)
            {
                ModelState.AddModelError(string.Empty, "El destino seleccionado no existe.");
                CargarDropdownDestinos();
                return View(model);
            }
            var reservaEntidad = new Reserva
            {
                IdDestino = model.IdDestino,
                FechaInicio = model.FechaInicio,
                FechaFin = model.FechaFin,
                CantidadPasajeros = model.CantidadPasajeros,
                Eliminado = false
            };
            _reservaLogica.AgregarReserva(reservaEntidad);

            // Mensaje de éxito para la vista Visualizar
            TempData["Success"] = "Reserva registrada correctamente.";

            return RedirectToAction("Visualizar");
        }

        [HttpGet]
        public IActionResult EliminarReserva(int Id)
        {
            _reservaLogica.EliminarReserva(Id);

            // Mensaje de éxito para la vista Visualizar
            TempData["Success"] = "Reserva eliminada correctamente.";

            return RedirectToAction("Visualizar");
        }

        private void CargarDropdownDestinos()
        {
            var destinos = _destinoLogica.ObtenerDestinos();
            ViewBag.Destinos = destinos;
        }

        [HttpGet]
        public IActionResult Visualizar(int? IdDestino)
        {
            CargarDropdownDestinos();
            if (IdDestino.HasValue)
            {
                ViewBag.IdReserva = IdDestino.Value;
                return View(_reservaLogica.ObtenerReservasPorDestino(IdDestino.Value));
            }
            else
            {
                return View(_reservaLogica.ObtenerTodasLasReservas());
            }
        }
    }
}

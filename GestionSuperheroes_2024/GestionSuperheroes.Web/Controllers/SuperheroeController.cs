using GestionSuperheroes.Data.EF;
using GestionSuperheroes.Servicios;
using GestionSuperheroes.Web.Models;
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
            var universos = _universoServicio.ObtenerUniversos();
            ViewBag.Universos = universos;
            return View();
        }

        [HttpPost]
        public IActionResult AgregarSuperheroe(SuperheroeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                CargarDropdownUniversos();
                return View(model);
            }
            var universos = _universoServicio.ObtenerUniverosPorId(model.IdUniverso);
            if (universos == null)
            {
                ModelState.AddModelError("IdDestino", "El universo destino no existe.");
                CargarDropdownUniversos();
                return View(model);
            }
            var superheroe = new Superheroe
            {
                NombreSuperheroe = model.NombreSuperheroe,
                IdUniverso = model.IdUniverso,
                Eliminado = false
            };
            _superheroeServicio.AgregarSuperheroe(superheroe);

            TempData["Success"] = "Reserva registrada correctamente.";

            return RedirectToAction("ListarSuperheroes");
        }

        [HttpGet]
        public IActionResult ListarSuperheroes(int? IdUniverso)
        {
            CargarDropdownUniversos();
            if(IdUniverso.HasValue)
            {
                ViewBag.IdUniverso = IdUniverso.Value;
                return View(_superheroeServicio.ObtenerSuperheroesPorDestino(IdUniverso.Value));
            }
            else
            {
                return View(_superheroeServicio.ObtenerTodosLosSuperheroes());
            }
        }

        [HttpGet]
        public IActionResult EliminarSuperheroe(int id)
        {
            _superheroeServicio.EliminarSuperheroe(id);
            TempData["Success"] = "Superhéroe eliminado correctamente.";
            return RedirectToAction("ListarSuperheroes");
        }

        private void CargarDropdownUniversos()
        {
            var universos = _universoServicio.ObtenerUniversos();
            ViewBag.Universos = universos;
        }
    }

}
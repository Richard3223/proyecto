using Microsoft.AspNetCore.Mvc;
using proyecto.Models;
using Proyecto.Services;

namespace Proyecto.Controllers
{
    public class EquipoController : Controller
    {
        private readonly EquipoService _equipoService;

        public EquipoController(EquipoService equipoService)
        {
            _equipoService = equipoService;
        }

        public IActionResult Index()
        {
            var equipos = _equipoService.ObtenerEquipos();
            return View(equipos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                _equipoService.CrearEquipo(equipo);
                return RedirectToAction(nameof(Index));
            }
            return View(equipo);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var equipo = _equipoService.ObtenerEquipoPorId(id);
            if (equipo == null)
            {
                return NotFound();
            }
            return View(equipo);
        }

        [HttpPost]
        public IActionResult Edit(int id, Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                _equipoService.ActualizarEquipo(id,equipo);
                return RedirectToAction(nameof(Index));
            }
            return View(equipo);
        }

        public IActionResult Delete(int id)
        {
            _equipoService.EliminarEquipo(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

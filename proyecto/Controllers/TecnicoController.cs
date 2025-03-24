using Microsoft.AspNetCore.Mvc;
using proyecto.Models;
using Proyecto.Services;

namespace Proyecto.Controllers
{
    public class TecnicoController : Controller
    {
        private readonly TecnicoService _tecnicoService;

        public TecnicoController(TecnicoService tecnicoService)
        {
            _tecnicoService = tecnicoService;
        }

        public IActionResult Index()
        {
            var tecnicos = _tecnicoService.ObtenerTecnicos();
            return View(tecnicos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Tecnico tecnico)
        {
            if (ModelState.IsValid)
            {
                _tecnicoService.CrearTecnico(tecnico);
                return RedirectToAction(nameof(Index));
            }
            return View(tecnico);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var tecnico = _tecnicoService.ObtenerTecnicoPorId(id);
            if (tecnico == null)
            {
                return NotFound();
            }
            return View(tecnico);
        }

        [HttpPost]
        public IActionResult Edit(int id, Tecnico tecnico)
        {
            if (ModelState.IsValid)
            {
                _tecnicoService.ActualizarTecnico(id, tecnico);
                return RedirectToAction(nameof(Index));
            }
            return View(tecnico);
        }

        public IActionResult Delete(int id)
        {
            _tecnicoService.EliminarTecnico(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

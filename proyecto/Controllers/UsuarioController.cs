using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using proyecto.Models;
using Proyecto.Services;  

namespace Proyecto.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public IActionResult Index()
        {
            var usuarios = _usuarioService.ObtenerUsuarios();
            return View(usuarios);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _usuarioService.CrearUsuario(usuario);
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var usuario = _usuarioService.ObtenerUsuarioPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Edit(int id, Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _usuarioService.ActualizarUsuario(id, usuario);
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // Eliminar un usuario
        public IActionResult Delete(int id)
        {
            _usuarioService.EliminarUsuario(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
